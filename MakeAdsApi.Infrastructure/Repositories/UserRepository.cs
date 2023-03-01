using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Users;
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
    
    public async Task<User?> GetWithProfileByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context
            .Users
            .Include(x => x.Profile)
            .ThenInclude(x => x.Avatar)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<User?> GetWithOfficeAndCompanyByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context
            .Users
            .Include(x => x.Office)
            .ThenInclude(x => x.Company)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);    
    }

    public async Task<PagedList<User>> GetPaginatedWithSearchAsync(int page, int pageSize, string? search = null,
        CancellationToken cancellationToken = default)
    {
        var query = Context
            .Users.Include(x => x.Profile).AsQueryable();

        if (!String.IsNullOrWhiteSpace(search))
        {
            string trimmedSearch = search.Trim();
            query = query
                .Where(x =>
                    x.Email.Contains(trimmedSearch)
                    || (x.Profile != null &&
                        (x.Profile.FirstName.Contains(trimmedSearch) ||
                         x.Profile.LastName.Contains(trimmedSearch)
                        )
                    )
                );
        }

        return await PagedList<User>.ToPagedListAsync(query.AsNoTracking(), page, pageSize, cancellationToken);
    }
}