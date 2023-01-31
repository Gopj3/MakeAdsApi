using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class BudgetRepository: GenericRepository<Budget>, IBudgetRepository
{
    public BudgetRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public async Task<PagedList<Budget>> GetPaginatedWithCompanyAsync(int page, int pageSize, string? search = null,
        CancellationToken cancellationToken = default)
    {
        var query = Context
            .Budgets.Include(x => x.Company).AsQueryable();

        if (!String.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Title.Contains(search.Trim()));
        }

        return await PagedList<Budget>.ToPagedList(query.AsNoTracking(), page, pageSize);
    }
}