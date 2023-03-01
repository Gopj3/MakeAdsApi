using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Helpers;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.Users;
using MakeAdsApi.Application.Enums;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Entities.Offices;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Enums;

namespace MakeAdsApi.Application.Services.Users;

public class UsersAutoCreateService : IUsersAutoCreateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFilesHelper _filesHelper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UsersAutoCreateService(
        IUnitOfWork unitOfWork,
        IFilesHelper filesHelper,
        IPasswordHasher<User> passwordHasher
    )
    {
        _unitOfWork = unitOfWork;
        _filesHelper = filesHelper;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> CreateUserAndRelatedEntitiesAsync(
        RetailDataPropertyApiResponse apiResponse,
        Company company,
        CancellationToken cancellationToken
    )
    {
        var role = await _unitOfWork.RoleRepository
            .GetByExpressionFirstAsync(x => x.Title == RoleTitle.User.Value, cancellationToken);

        var userProfileId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        
        return new User
        {
            Id = userId,
            Email = apiResponse.EmployeeEmail,
            Password = _passwordHasher.HashPassword(String.Empty),
            IsPasswordAutomaticGenerated = true,
            UserRoles = new List<UserRole> { new() { Id = Guid.NewGuid(), RoleId = role!.Id, UserId = userId } },
            Profile = new UserProfile
            {
                Id = userProfileId,
                FirstName = apiResponse.EmployeeName.Split(" ")[0],
                LastName = apiResponse.EmployeeName.Split(" ")[1],
                Title = apiResponse.EmployeeTitle,
                Phone = apiResponse.EmployeePhone,
                Avatar = await UploadAvatarAsync(apiResponse, userProfileId, cancellationToken)
            },
            Office = await CreateOfficeAsync(apiResponse, company)
        };
    }

    private async Task<Office> CreateOfficeAsync(RetailDataPropertyApiResponse result, Company company)
    {
        var office = await _unitOfWork.OfficeRepository.GetByExpressionFirstAsync(
            x => x.ExternalId == result.ExternalOfficeId
        );

        if (office is not null)
        {
            return office;
        }

        return new Office
        {
            Id = Guid.NewGuid(),
            Title = result.OfficeTitle,
            ExternalId = result.ExternalOfficeId,
            CompanyId = company.Id
        };
    }

    private async Task<UserProfileAvatar?> UploadAvatarAsync(
        RetailDataPropertyApiResponse result,
        Guid userProfileId,
        CancellationToken cancellationToken
    )
    {
        var extension = _filesHelper.ExtensionFromUrl(result.EmployeeAvatar);
        var fileName = _filesHelper.GenerateFileName(extension);

        var preSignedUrl =
            await _filesHelper.UploadImageToAwsFromUrlAsync(result.EmployeeAvatar, Folders.Avatars, fileName, cancellationToken);

        if (preSignedUrl is not null)
        {
            return new UserProfileAvatar
            {
                UserProfileId = userProfileId,
                FileName = fileName,
                FileExtension = extension,
                PreSignedUrl = preSignedUrl
            };
        }

        return null;
    }
}