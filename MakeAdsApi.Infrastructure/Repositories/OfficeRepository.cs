using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class OfficeRepository: GenericRepository<Office>, IOfficeRepository
{
    public OfficeRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public async Task<Office?> GetWithCompanyByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Offices.Include(x => x.Company)
            .Where(o => o.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}