using MakeAdsApi.Application.Budgets.Admin.Queries.Lists;
using MakeAdsApi.Application.Companies.Admin.Commands;
using MakeAdsApi.Application.Companies.Admin.Queries.List;
using MakeAdsApi.Application.Companies.Admin.Queries.Single;
using MakeAdsApi.Contracts.Admin.Companies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class CompaniesController : AdminApiController
{
    private readonly IMediator _mediator;

    public CompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        if (!Guid.TryParse(id, out var companyId))
        {
            return Problem("Invalid company id provided");
        }
        
        var res = await _mediator.Send(new GetCompanyByIdQuery(companyId));

        return res.Match(
            x => Ok(x),
            err => Problem(err));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _mediator.Send(new GetAllCompaniesQuery());
        
        return res.Match(
            x => Ok(x),
            err => Problem(err)); 
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync( 
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "pageSize")] int pageSize = 10,
        [FromQuery(Name = "search")] string? search = null
    )
    {
        var query = new PaginatedCompaniesQuery(page, pageSize, search);
        var res = await _mediator.Send(query);

        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEditCompanyRequest request)
    {
        if (!Guid.TryParse(request.RetailDataProviderId, out var providerId))
        {
            return Problem("Invalid provider id provided");
        }

        var command = new CreateCompanyCommand(
            request.Title,
            request.ExternalId,
            providerId);
        
        var res = await _mediator.Send(command);
        
        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] CreateEditCompanyRequest request)
    {
        if (!Guid.TryParse(request.RetailDataProviderId, out var providerId))
        {
            return Problem("Invalid provider id provided");
        }

        var command = new UpdateCompanyCommand(
            id,
            request.Title,
            request.ExternalId,
            providerId);
        
        var res = await _mediator.Send(command);
        
        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }
    
    [HttpGet("{id}/budgets")]
    public async Task<IActionResult> GetBudgetsPaginatedAsync
    (
        string id,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 5,
        [FromQuery] string? search = null)
    {
        if (!Guid.TryParse(id, out var companyId))
        {
            return Problem("Invalid company id provided");
        }
        
        var query = new PaginatedBudgetsQuery(companyId, page, pageSize, search);
        var res = await _mediator.Send(query);

        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }
}