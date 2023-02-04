using MakeAdsApi.Application.BudgetItems.Admin.Queries.Lists;
using MakeAdsApi.Application.Budgets.Admin.Commands;
using MakeAdsApi.Application.Budgets.Admin.Queries.Single;
using MakeAdsApi.Contracts.Admin.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class BudgetsController : AdminApiController
{
    private readonly IMediator _mediator;

    public BudgetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        if (!Guid.TryParse(id, out var budgetId))
        {
            return Problem("Invalid budget id provided");
        }
        
        var query = new GetBudgetByIdQuery(budgetId);
        var res = await _mediator.Send(query);
        
        return res.Match(Ok, Problem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEditBudgetRequest request)
    {
        if (!Guid.TryParse(request.CompanyId, out var companyId))
        {
            return Problem("Invalid company id provided");
        }

        if (!BudgetType.TryFromName(request.Type.ToLower(), out var budgetType))
        {
            return Problem("Invalid budget type provided");
        }

        var command = new CreateBudgetCommand(request.Title, budgetType, companyId);
        var res = await _mediator.Send(command);
        
        return res.Match(Ok, Problem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] CreateEditBudgetRequest request)
    {
        if (!Guid.TryParse(request.CompanyId, out var companyId))
        {
            return Problem("Invalid company id");
        }
        
        if (!Guid.TryParse(id, out var budgetId))
        {
            return Problem("Invalid id");
        }
        
        if (!BudgetType.TryFromName(request.Type.ToLower(), out var budgetType))
        {
            return Problem("Invalid budget type provided");
        }

        var command = new UpdateBudgetCommand(budgetId, request.Title, budgetType, companyId);
        var res = await _mediator.Send(command);
        
        return res.Match(Ok, Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        if (!Guid.TryParse(id, out var budgetId))
        {
            return Problem("Invalid ");
        }

        var command = new DeleteBudgetCommand(budgetId);
        var res = await _mediator.Send(command);
        
        return res.Match(x => Ok(), Problem);
    }
    
    [HttpGet("{id}/budget-items")]
    public async Task<IActionResult> GetPaginatedBudgetItemsAsync(
        string id,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 5,
        [FromQuery] string? search = null
    )
    {
        if (!Guid.TryParse(id, out var budgetId))
        {
            return Problem("Invalid budget id provided");
        }
        
        var query = new PaginatedBudgetItemsQuery(budgetId, page, pageSize, search);
        var res = await _mediator.Send(query);
        
        return res.Match(Ok, Problem);
    }
}