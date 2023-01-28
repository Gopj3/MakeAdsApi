using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Files;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class UserProfileAvatarRepository: GenericRepository<UserProfileAvatar>, IUserProfileAvatarRepository
{
    public UserProfileAvatarRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public async Task<List<UserProfileAvatar>> GetNeedsToBeUpdatedAsync(CancellationToken cancellationToken = default)
    {
        return await Context.UserProfileAvatars.Where(
            x => x.PreSignedUrl != null && x.PreSignedUrlCreatedAt != null
            && x.PreSignedUrlCreatedAt.Value.AddDays(6) < DateTime.UtcNow)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}