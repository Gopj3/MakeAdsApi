using System;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IBudgetItemRepository: IGenericRepository<BudgetItem>
{
    Task<PagedList<BudgetItem>> GetPaginatedByBudgetIdAsync(int page, int pageSize, Guid budgetId, string? search = null,
        CancellationToken cancellationToken = default);

    Task<int> CountBudgetItemsOfBudgetByTypeAsync(Guid budgetId, BudgetItemType type, CancellationToken cancellationToken);
}