using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Authentication.Models;
using MakeAdsApi.Application.Authentication.Queries;
using MakeAdsApi.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Authentication;

public class LoginController : ApiController
{
    private IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var command = new LoginQuery(request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }
}