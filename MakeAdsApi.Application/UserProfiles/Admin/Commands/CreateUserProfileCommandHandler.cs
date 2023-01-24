using System;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.AWS;
using MakeAdsApi.Application.UserProfiles.Admin.Models;
using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.UserProfiles.Admin.Commands;

public class CreateUserProfileCommandHandler: IRequestHandler<CreateUserProfileCommand, ErrorOr<UserProfileViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAwsS3Service _s3Service;

    public CreateUserProfileCommandHandler(IUnitOfWork unitOfWork, IAwsS3Service s3Service)
    {
        _unitOfWork = unitOfWork;
        _s3Service = s3Service;
    }

    public async Task<ErrorOr<UserProfileViewModel>> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
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
        
        UserProfile userProfile = new()
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Title = request.Title,
            Phone = request.Phone,
            Avatar = preSignedUrl is not null ? new UserProfileAvatar
            {
                Id = Guid.NewGuid(),
                FileName = request.Avatar!.FileName,
                FileExtension = request.Avatar!.ContentType,
                PreSignedUrl = preSignedUrl,
                PreSignedUrlCreatedAt = DateTime.UtcNow
            } : null,
        };

        await _unitOfWork.UserProfileRepository.CreateAsync(userProfile, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return UserProfileViewModel.From(userProfile);
    }
}