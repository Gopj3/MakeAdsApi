using MakeAdsApi.Application.Budgets.Admin.Commands;
using MakeAdsApi.Application.Budgets.Admin.Quries.Lists;
using MakeAdsApi.Contracts.Admin.Budgets;
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

    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync(
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 5,
        [FromQuery] string? search = null)
    {
        var query = new PaginatedBudgetsQuery(page, pageSize, search);
        var res = await _mediator.Send(query);

        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEditBudgetRequest request)
    {
        if (!Guid.TryParse(request.CompanyId, out var companyId))
        {
            return Problem("Invalid company id provided");
        }

        return Ok();
    }

    [HttpPut("id")]
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

        var command = new UpdateBudgetCommand(budgetId, request.Title, companyId);
        var res = await _mediator.Send(command);
        
        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }
}