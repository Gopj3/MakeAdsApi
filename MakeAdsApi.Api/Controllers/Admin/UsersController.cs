using ErrorOr;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.UserProfiles.Admin.Commands;
using MakeAdsApi.Application.UserProfiles.Admin.Queries;
using MakeAdsApi.Application.Users.Commands.Admin;
using MakeAdsApi.Application.Users.Models.Responses;
using MakeAdsApi.Application.Users.Queries.Admin.Lists;
using MakeAdsApi.Application.Users.Queries.Admin.Single;
using MakeAdsApi.Contracts.Admin.UserProfiles;
using MakeAdsApi.Contracts.Admin.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class UsersController : AdminApiController
{
    private IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateEditUserRequest request)
    {
        var result = await _mediator.Send(
            new CreateUserCommand(request.Email, request.RoleIds)
        );

        return result.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsersListPaginatedAsync(
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "pageSize")] int pageSize = 10,
        CancellationToken token = default
    )
    {
        var query = new GetPaginatedUserQuery(page, pageSize);
        ErrorOr<BaseViewListModel<UserViewModel>> users = await _mediator.Send(query, token);

        return users.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] string id)
    {
        if (!Guid.TryParse(id, out var userId))
            return Problem(new List<Error> { Error.Failure() });

        var query = new GetSingleUserByIdQuery(userId);
        ErrorOr<UserViewModel> user = await _mediator.Send(query);

        return user.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditUserByIdAsync([FromRoute] string id, [FromBody] CreateEditUserRequest request)
    {
        if (!Guid.TryParse(id, out var userId))
            return Problem(new List<Error> { Error.Failure() });

        var query = new EditUserCommand(userId, request.Email, request.RoleIds);
        ErrorOr<object> user = await _mediator.Send(query);

        return user.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }


    [HttpGet("{id}/user-profile")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        if (!Guid.TryParse(id, out var userId))
        {
            return Problem("Invalid user id");
        }

        var result = await _mediator.Send(new GetUserProfileQuery(userId));

        return result.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }

    [HttpPost("{id}/user-profile")]
    public async Task<IActionResult> Create([FromRoute] string id, [FromForm] CreateEditUserProfileRequest request)
    {
        if (!Guid.TryParse(id, out var userId))
        {
            return Problem("Invalid user id");
        }

        CreateUserProfileCommand command = new(
            userId, request.FirstName,
            request.LastName,
            request.Title,
            request.Phone,
            request.Avatar
        );
        var result = await _mediator.Send(command);

        return result.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }
}