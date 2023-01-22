using ErrorOr;
using MakeAdsApi.Application.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class RolesController: AdminApiController
{
    private readonly IMediator _mediator;
    
    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        
        return roles.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }
}