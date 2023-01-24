using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.UserProfiles.Admin.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.UserProfiles.Admin.Queries;

public class GetUserProfileQueryHandler: IRequestHandler<GetUserProfileQuery, ErrorOr<UserProfileViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetUserProfileQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<UserProfileViewModel>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var userProfile = await _unitOfWork
            .UserProfileRepository
            .GetByExpressionFirstAsync(x => x.UserId == request.UserId, cancellationToken);

        if (userProfile is null)
        {
            return DomainErrors.UserProfile.NotFound;
        }

        return UserProfileViewModel.From(userProfile);
    }
}