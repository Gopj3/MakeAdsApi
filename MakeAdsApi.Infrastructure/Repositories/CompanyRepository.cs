using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    public CompanyRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public async Task<Company?> GetCompanyWithProviderByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Companies
            .IgnoreQueryFilters()
            .Include(x => x.RetailDataProvider)
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Company?> GetCompanyWithRetailProviderByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        return await Context.Companies
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Include(x => x.RetailDataProvider)
            .Include(x => x.Offices)
            .ThenInclude(x => x.Users.Where(u => u.Id == userId))
            .SingleOrDefaultAsync(cancellationToken);
    }
}