using MakeAdsApi.Application.Users.Commands.Common;
using MakeAdsApi.Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Customers;

public class ConnectUsersFromRetailDataController: ApiController
{
    private readonly IMediator _mediator;

    public ConnectUsersFromRetailDataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> ConnectUserFromRetailDataAsync(
        [FromBody] ConnectUserRequest request)
    {
        if (!Guid.TryParse(request.CompanyId, out var companyId))
        {
            return Problem("Invalid company id provided");
        }

        var command = new ConnectUserFromRetailDataCommand(companyId, request.PropertyId);
        var res = await _mediator.Send(command);

        return res.Match(Ok, Problem);
    }
}