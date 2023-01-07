using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Authentication.Models;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork,
        IPasswordHasher<User> passwordHasher
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.FindByEmailAsync(request.Email, cancellationToken);

        if (user is null)
            return DomainErrors.User.InvalidCredentials;

        var isPasswordValid = _passwordHasher.VerifyHashedPassword(user.Password, request.Password);
        
        if (!isPasswordValid) 
            return DomainErrors.User.InvalidCredentials; 
        
        string accessToken = _jwtTokenGenerator.GenerateToken(user.Id, user.Email);

        return new AuthenticationResult(user.Email, accessToken);
    }
}