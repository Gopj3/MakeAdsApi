using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Authentication.Models;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;
using MakeAdsApi.Application.Common.Abstractions.Services.Users;
using MakeAdsApi.Application.Exceptions;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Users.Commands.Common;

public class ConnectUserFromRetailDataCommandHandler
    : IRequestHandler<ConnectUserFromRetailDataCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRetailDataProviderHttpService _retailDataProviderHttpService;
    private readonly IUsersAutoCreateService _usersAutoCreateService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public ConnectUserFromRetailDataCommandHandler(
        IUnitOfWork unitOfWork,
        IRetailDataProviderHttpService retailDataProviderHttpService,
        IUsersAutoCreateService usersAutoCreateService,
        IJwtTokenGenerator jwtTokenGenerator
    )
    {
        _unitOfWork = unitOfWork;
        _retailDataProviderHttpService = retailDataProviderHttpService;
        _usersAutoCreateService = usersAutoCreateService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        ConnectUserFromRetailDataCommand request,
        CancellationToken cancellationToken
    )
    {
        var company =
            await _unitOfWork.CompanyRepository.GetCompanyWithProviderByIdAsync(request.CompanyId, cancellationToken);

        if (company is null)
        {
            return DomainErrors.Company.NotFound;
        }

        if (company.RetailDataProvider.UpdatePropertyDataUrl is null)
        {
            return DomainErrors.RetailDataProvider.NotFound;
        }

        var apiResponse = await _retailDataProviderHttpService.GetRetailPropertyDataAsync(
            company.RetailDataProvider.UpdatePropertyDataUrl,
            company.ExternalId,
            request.PropertyId,
            cancellationToken
        );

        if (apiResponse is null) throw new RetailDataProviderException("No response from retail data provider");

        var user = await _unitOfWork.UserRepository.GetByExpressionFirstAsync(
            x => x.Email == apiResponse.EmployeeEmail,
            cancellationToken
        );

        if (user is not null)
        {
            return new AuthenticationResult(user.Email, _jwtTokenGenerator.GenerateToken(user));
        }

        var newUser = await _usersAutoCreateService
            .CreateUserAndRelatedEntitiesAsync(apiResponse!, company, cancellationToken);

        await _unitOfWork.UserRepository.CreateAsync(newUser, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthenticationResult(newUser.Email, _jwtTokenGenerator.GenerateToken(newUser));
    }
}