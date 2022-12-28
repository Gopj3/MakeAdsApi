using ErrorOr;
using MakeAdsApi.Application.Authentication.Models;
using MediatR;

namespace MakeAdsApi.Application.Authentication.Queries;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Email { get; } = Email;
    public string Password { get; } = Password;
}