using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Files;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUserProfileAvatarRepository: IGenericRepository<UserProfileAvatar>
{
    Task<List<UserProfileAvatar>> GetNeedsToBeUpdatedAsync(CancellationToken cancellationToken = default);
}