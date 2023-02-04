using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class BudgetItemRepository : GenericRepository<BudgetItem>, IBudgetItemRepository
{
    public BudgetItemRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public Task<PagedList<BudgetItem>> GetPaginatedByBudgetIdAsync(int page, int pageSize, Guid budgetId,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var query = Context.BudgetItems.Where(x => x.BudgetId == budgetId);

        if (search is not null)
        {
            List<BudgetItemType> types = BudgetItemType.List
                .Where(x => x.Value.Contains(search.Trim())).ToList();

            if (types.Any())
            {
                query = query.Where(x => types.Contains(x.Type));
            }
        }

        return PagedList<BudgetItem>.ToPagedListAsync(query.AsNoTracking().AsQueryable(), page, pageSize,
            cancellationToken);
    }

    public async Task<int> CountBudgetItemsOfBudgetByTypeAsync(Guid budgetId, BudgetItemType type,
        CancellationToken cancellationToken)
    {
        return await Context.BudgetItems.Where(x => x.BudgetId == budgetId && x.Type.Equals(type))
            .CountAsync(cancellationToken);
    }
}