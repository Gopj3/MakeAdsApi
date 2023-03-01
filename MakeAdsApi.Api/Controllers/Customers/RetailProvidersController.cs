using System.Net;
using MakeAdsApi.Api.Extensions;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MakeAdsApi.Application.RetailProviders.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Customers;

public class RetailProvidersController: CustomersApiController
{
    private readonly IMediator _mediator;

    public RetailProvidersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("data/{propertyId}")]
    [ProducesResponseType(typeof(RetailDataApiResponseViewModel), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> GetRetailProviderPropertyDataAsync(string propertyId)
    {
        var userId = HttpContext.GetUserId();
        var query = new GetRetailDataForPropertyQuery(propertyId, userId);
        var res = await _mediator.Send(query);

        return res.Match(Ok, Problem);
    }
}