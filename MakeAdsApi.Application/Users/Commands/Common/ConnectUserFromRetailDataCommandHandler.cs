using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Helpers;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Enums;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Users.Commands.Common;

public class ConnectUserFromRetailDataCommandHandler : IRequestHandler<ConnectUserFromRetailDataCommand, ErrorOr<Unit>>
{
    // private readonly IUnitOfWork _unitOfWork;
    // private readonly IRetailDataProviderHttpService _retailDataProviderHttpService;
    // private readonly IPasswordHasher<User> _passwordHasher;
    // private readonly IFilesHelper _filesHelper;

    public ConnectUserFromRetailDataCommandHandler(
        // IUnitOfWork unitOfWork,
        // IRetailDataProviderHttpService retailDataProviderHttpService,
        // IPasswordHasher<User> passwordHasher,
        // IFilesHelper filesHelper
    )
    {
        // _unitOfWork = unitOfWork;
        // _retailDataProviderHttpService = retailDataProviderHttpService;
        // _passwordHasher = passwordHasher;
        // _filesHelper = filesHelper;
    }

    public async Task<ErrorOr<Unit>> Handle(
        ConnectUserFromRetailDataCommand request,
        CancellationToken cancellationToken
    )
    {
        //     var company =
        //         await _unitOfWork.CompanyRepository.GetCompanyWithProviderByIdAsync(request.CompanyId, cancellationToken);
        //     
        //     if (company is null)
        //     {
        //         return DomainErrors.Company.NotFound;
        //     }
        //     
        //     if (company.RetailDataProvider.UpdatePropertyDataUrl is null)
        //     {
        //         return DomainErrors.RetailDataProvider.NotFound;
        //     }
        //     
        //     var role = await _unitOfWork.RoleRepository
        //         .GetByExpressionFirstAsync(x => x.Title == RoleTitle.User.Value, cancellationToken);
        //
        //     var result = await _retailDataProviderHttpService.GetRetailPropertyDataAsync(
        //         company.RetailDataProvider.UpdatePropertyDataUrl,
        //         company.ExternalId,
        //         request.PropertyId,
        //         cancellationToken
        //     );
        //     
        //     var userId = Guid.NewGuid();
        //     var userProfileId = Guid.NewGuid();
        //     var user = CreateUser(result!, userId, role!);
        //     
        //     user.Profile = new UserProfile(
        //         userProfileId,
        //         result!.EmployeeName.Split(" ")[0],
        //         result!.EmployeeName.Split(" ")[1],
        //         result.EmployeeTitle,
        //         result.EmployeePhone,
        //         await UploadAvatarAsync(result, userProfileId, cancellationToken),
        //         userId
        //     );
        //     
        //     await _unitOfWork.UserRepository.CreateAsync(user, cancellationToken);
        //     await _unitOfWork.SaveChangesAsync(cancellationToken);
        //
        return Unit.Value;
        // }
        //
        // private User CreateUser(RetailDataPropertyApiResponse result, Guid userId, Role role)
        // {
        //     return new User(
        //         userId,
        //         result!.EmployeeEmail,
        //         _passwordHasher.HashPassword(String.Empty),
        //         new List<UserRole>
        //         {
        //             UserRole.Create(userId, role!)
        //         }
        //     );
        // }
        //
        // private async Task<UserProfileAvatar?> UploadAvatarAsync(
        //     RetailDataPropertyApiResponse result,
        //     Guid userProfileId,
        //     CancellationToken cancellationToken
        // )
        // {
        //     var extension = _filesHelper.ExtensionFromUrl(result.EmployeeAvatar);
        //     var fileName = _filesHelper.GenerateFileName(extension);
        //
        //     var preSignedUrl =
        //         await _filesHelper.UploadImageToAwsFromUrlAsync(result.EmployeeAvatar, fileName, cancellationToken);
        //
        //     if (preSignedUrl is not null)
        //     {
        //         return new UserProfileAvatar(
        //             userProfileId,
        //             fileName,
        //             extension,
        //             preSignedUrl
        //         );
        //     }
        //
        //     return null;
        // }
    }
}