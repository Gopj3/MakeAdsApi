using MakeAdsApi.Api.Extensions;
using MakeAdsApi.Application.Properties.Commands;
using MakeAdsApi.Contracts.Customers.Properties;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Customers.Properties;

public class PropertiesController: CustomersApiController
{
    private readonly IMediator _mediator;
    
    public PropertiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterPropertyAsync([FromBody] RegisterPropertyRequest request)
    {
        var userId = HttpContext.GetUserId();
        var command = new RegisterPropertyCommand(request.PropertyId, request.Address, userId);
        var res = await _mediator.Send(command);
        return res.Match(Ok, Problem);
    }
}