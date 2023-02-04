using MakeAdsApi.Application.BudgetItems.Admin.Commands;
using MakeAdsApi.Application.BudgetItems.Admin.Queries.Single;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Contracts.Admin.BudgetItems;
using MakeAdsApi.Domain.Enums.Budgets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class BudgetItemsController : AdminApiController
{
    private readonly IMediator _mediator;

    public BudgetItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        if (!Guid.TryParse(id, out var budgetItemId))
        {
            return Problem("Invalid budget item id provided");
        }

        var query = new GetByIdBudgetItemQuery(budgetItemId);
        var res = await _mediator.Send(query);

        return res.Match(Ok, Problem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEditBudgetItemRequest request)
    {
        if (!Guid.TryParse(request.BudgetId, out var budgetId))
        {
            return Problem("Invalid budget id provided");
        }

        if (!BudgetItemType.TryFromName(request.Type.ToLower(), out var budgetItemType))
        {
            return Problem("Invalid budget item type provided");
        }

        var command = new CreateBudgetItemCommand(budgetId, request.Value, budgetItemType);
        var res = await _mediator.Send(command);

        return res.Match(Ok, Problem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] CreateEditBudgetItemRequest request)
    {
        if (!Guid.TryParse(request.BudgetId, out var budgetId))
        {
            return Problem("Invalid budget id provided");
        }
        
        if (!BudgetItemType.TryFromValue(request.Type, out var budgetItemType))
        {
            return Problem("Invalid budget item type provided");
        }
        
        var command = new UpdateBudgetItemCommand(budgetId, request.Value, budgetItemType);
        var res = await _mediator.Send(command);

        return res.Match(Ok, Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        if (!Guid.TryParse(id, out var budgetItemId))
        {
            return Problem("Invalid budget id provided");
        }

        var command = new DeleteBudgetItemCommand(budgetItemId);
        var res = await _mediator.Send(command);

        return res.Match(x => NoContent(), Problem);
    }
}