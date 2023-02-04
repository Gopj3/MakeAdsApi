using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class BudgetRepository : GenericRepository<Budget>, IBudgetRepository
{
    public BudgetRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public async Task<PagedList<Budget>> GetPaginatedWithCompanyAsync(
        int page,
        int pageSize,
        Guid companyId,
        string? search = null,
        CancellationToken cancellationToken = default
    )
    {
        var query = Context.Budgets
            .Include(x => x.Company)
            .Where(x => x.CompanyId == companyId)
            .AsQueryable();

        if (!String.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Title.Contains(search.Trim()));
        }

        return await PagedList<Budget>.ToPagedListAsync(query.AsNoTracking(), page, pageSize, cancellationToken);
    }

    public async Task<Budget?> GetByIdWithCompanyAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Budgets.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<int> CountBudgetsByBudgetTypeAndCompanyIdAsync(Guid companyId, BudgetType budgetType,
        CancellationToken cancellationToken)
    {
        return await Context.Budgets.Where(x => x.CompanyId == companyId && x.Type == budgetType)
            .CountAsync(cancellationToken);
    }
}