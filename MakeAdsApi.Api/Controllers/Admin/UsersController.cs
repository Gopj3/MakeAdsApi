using ErrorOr;
using MakeAdsApi.Application.Users.Models;
using MakeAdsApi.Application.Users.Queries.Lists;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class UsersController : AdminApiController
{
    private IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsersListPaginatedAsync(
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "pageSize")] int pageSize = 10,
        CancellationToken token = default
    )
    {
        var query = new GetPaginatedUserQuery(page, pageSize);
        ErrorOr<List<UserDto>> users = await _mediator.Send(query, token);

        return users.Match<IActionResult>(
            res => Ok(res),
            errors => Problem(errors)
        );
    }
}