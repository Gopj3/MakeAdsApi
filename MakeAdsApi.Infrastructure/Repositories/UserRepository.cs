using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Errors;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByExpressionWithRolesAsync(
        Expression<Func<User, bool>> filter,
        CancellationToken cancellationToken = default
    )
    {
        return await Context
            .Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(filter!, cancellationToken);
    }
}