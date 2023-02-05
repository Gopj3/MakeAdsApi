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

public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, ErrorOr<UserProfileViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAwsS3Service _s3Service;

    public CreateUserProfileCommandHandler(IUnitOfWork unitOfWork, IAwsS3Service s3Service)
    {
        _unitOfWork = unitOfWork;
        _s3Service = s3Service;
    }

    public async Task<ErrorOr<UserProfileViewModel>> Handle(CreateUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }

        string? preSignedUrl = null;

        if (request.Avatar is not null)
        {
            if (await _s3Service.WriteObjectAsync(request.Avatar, cancellationToken))
            {
                preSignedUrl = _s3Service.GetPreSignedUrl(request!.Avatar.FileName);
            }
        }

        Guid userProfileId = Guid.NewGuid();

        var avatar = preSignedUrl is not null
            ? new UserProfileAvatar(
                userProfileId, 
                request.Avatar!.FileName,
                request.Avatar!.ContentType,
                preSignedUrl)
            : null;

        UserProfile userProfile = new(
            userProfileId,
            request.FirstName,
            request.LastName,
            request.Title,
            request.Phone,
            avatar,
            user.Id
        );

        await _unitOfWork.UserProfileRepository.CreateAsync(userProfile, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UserProfileViewModel.From(userProfile);
    }
}