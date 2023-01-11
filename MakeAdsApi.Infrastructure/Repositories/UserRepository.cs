using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public async Task<User?> FindByEmailWithRolesAsync(
        string email,
        CancellationToken cancellationToken = default
    )
    {
        return await Context
            .Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public override async Task<List<User>> GetEntitiesPaginated(
        int page,
        int pageSize,
        CancellationToken token)
    {
        return await Context.Users.Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .Include(x => x.Profile)
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);
    }
}