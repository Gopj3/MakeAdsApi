using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Authentication.Models;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MediatR;

namespace MakeAdsApi.Application.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        Guid userId = new Guid();
        string accessToken = _jwtTokenGenerator.GenerateToken(userId, "someEmail@gmail.com");

        return new AuthenticationResult("", accessToken, 25);
    }
}