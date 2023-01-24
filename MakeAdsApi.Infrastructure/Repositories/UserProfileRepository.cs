using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class UserProfileRepository: GenericRepository<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public override async Task<UserProfile?> GetByExpressionFirstAsync(Expression<Func<UserProfile, bool>> filter, CancellationToken token = default)
    {
       return await Context.UserProfiles
           .Include(x => x.Avatar)
           .FirstOrDefaultAsync(filter , token);
    }
}