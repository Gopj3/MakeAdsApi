using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.AWS;
using MakeAdsApi.Application.UserProfiles.Shared.Models;
using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.UserProfiles.Admin.Commands;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, ErrorOr<UserProfileViewModel>>
{
    private readonly IAwsS3Service _awsS3Service;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserProfileCommandHandler(IAwsS3Service awsS3Service, IUnitOfWork unitOfWork)
    {
        _awsS3Service = awsS3Service;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<UserProfileViewModel>> Handle(
        UpdateUserProfileCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.UserRepository.GetWithProfileById(request.UserId, cancellationToken);

        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }

        if (user.Profile is null)
        {
            return DomainErrors.UserProfile.NotFound;
        }

        if (request.Avatar is not null)
        {
            var avatarUploadingResult = await UpdateAvatar(request, user, cancellationToken);
            if (!String.IsNullOrEmpty(avatarUploadingResult))
            {
                UpdateOrCreateAvatarOnProfile(user.Profile, request, avatarUploadingResult);
            }
        }

        user.Profile?.Update(
            request.FirstName,
            request.LastName,
            request.Title,
            request.Phone,
            user.Profile.Avatar
        );

        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UserProfileViewModel.From(user.Profile!);
    }

    private async Task<string?> UpdateAvatar(
        UpdateUserProfileCommand request,
        User user,
        CancellationToken cancellationToken
    )
    {
        if (user.Profile?.Avatar is not null)
        {
            await _awsS3Service.DeleteFileByFileNameAsync(user.Profile.Avatar.FileName);
        }

        var success = await _awsS3Service.WriteObjectAsync(request.Avatar!, cancellationToken);

        if (success)
        {
            return _awsS3Service.GetPreSignedUrl(request.Avatar!.FileName);
        }

        return null;
    }
    
    private void UpdateOrCreateAvatarOnProfile(UserProfile? profile, UpdateUserProfileCommand request, string preSignedUrl)
    {
        if (profile is null)
            return;
        
        if (profile.Avatar is not null)
        {
            profile.Avatar.Update(
                request.Avatar!.FileName,
                request.Avatar.ContentType,
                preSignedUrl
            );

            return;
        }

        profile.Avatar = new UserProfileAvatar
        {
            Id = Guid.NewGuid(),
            UserProfileId = profile.Id,
            FileName = request.Avatar!.FileName,
            FileExtension = request.Avatar.ContentType,
            PreSignedUrl = preSignedUrl
        };
    }
}