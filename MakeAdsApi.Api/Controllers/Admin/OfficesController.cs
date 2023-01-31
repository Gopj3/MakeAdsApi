using MakeAdsApi.Application.Offices.Admin.Commands;
using MakeAdsApi.Application.Offices.Admin.Queries.List;
using MakeAdsApi.Application.Offices.Admin.Queries.Single;
using MakeAdsApi.Contracts.Admin.Offices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class OfficesController : AdminApiController
{
    private readonly IMediator _mediator;

    public OfficesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync(
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 0,
        [FromQuery] string? search = null
    )
    {
        var query = new PaginatedOfficesQuery(page, pageSize, search);
        var res = await _mediator.Send(query);

        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        if (!Guid.TryParse(id, out var officeId))
        {
            return Problem("Invalid office id provided");
        }

        var res = await _mediator.Send(new GetOfficeByIdQuery(officeId));

        return res.Match(
            res => Ok(res),
            err => Problem(err)
            );
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEditOfficeRequest request)
    {
        if (!Guid.TryParse(request.CompanyId, out var companyId))
        {
            return Problem("Invalid company id provided");
        }

        var command = new CreateOfficeCommand(request.Title, request.ExternalId, companyId);
        var res = await _mediator.Send(command);
        
        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] CreateEditOfficeRequest request)
    {
        if (!Guid.TryParse(id, out var officeId))
        {
            return Problem("Invalid office id provided");
        }
        
        if (!Guid.TryParse(request.CompanyId, out var companyId))
        {
            return Problem("Invalid company id provided");
        }

        var command = new UpdateOfficeCommand(officeId, request.Title, request.ExternalId, companyId);
        var res = await _mediator.Send(command);
        
        return res.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }
}