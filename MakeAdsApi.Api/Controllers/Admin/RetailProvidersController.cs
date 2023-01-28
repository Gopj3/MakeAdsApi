using MakeAdsApi.Application.RetailProviders.Admin.Commands;
using MakeAdsApi.Application.RetailProviders.Admin.Queries.Lists;
using MakeAdsApi.Application.RetailProviders.Admin.Queries.Single;
using MakeAdsApi.Contracts.Admin.RetailDataProvider;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class RetailProvidersController : AdminApiController
{
    private readonly IMediator _mediator;

    public RetailProvidersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync(
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "pageSize")] int pageSize = 10,
        [FromQuery(Name = "search")] string? search = null
    )
    {
        var query = new GetPaginatedProviderQuery(page, pageSize, search);
        var result = await _mediator.Send(query);

        return result.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        if (Guid.TryParse(id, out var providerId))
        {
            var query = new SingleRetailDataProviderByIdQuery(providerId);
            var result = await _mediator.Send(query);

            return result.Match(
                res => Ok(res),
                errors => Problem(errors)
            );
        }

        return Problem("Invalid id");
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] RetailDataProviderRequest request)
    {
        var command = new CreateRetailDataProviderCommand(
            request.Title,
            request.FetchPropertyDataUrl,
            request.UpdatePropertyDataUrl,
            request.FetchUserDataUrl,
            request.UpdateUserDataUrl
        );

        var result = await _mediator.Send(command);

        return result.Match(
            res => Created(
                Url.Action(action: "GetById") ?? string.Empty,
                res
            ),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] RetailDataProviderRequest request)
    {
        if (Guid.TryParse(id, out var providerId))
        {
            var command = new UpdateRetailDataProviderCommand(
                providerId,
                request.Title,
                request.FetchPropertyDataUrl,
                request.UpdatePropertyDataUrl,
                request.FetchUserDataUrl,
                request.UpdateUserDataUrl
            );

            var result = await _mediator.Send(command);

            return result.Match(
                res => Ok(),
                errors => Problem(errors)
            );
        }

        return Problem("Invalid id");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (Guid.TryParse(id, out var providerId))
        {
            var command = new DeleteRetailDataProviderCommand(providerId);
            var result = await _mediator.Send(command);

            return result.Match(
                res => NoContent(),
                errors => Problem(errors)
            );
        }

        return Problem("Invalid id");
    }
}