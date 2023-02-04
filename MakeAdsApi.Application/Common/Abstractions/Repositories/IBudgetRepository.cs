using System;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IBudgetRepository : IGenericRepository<Budget>
{
    Task<PagedList<Budget>> GetPaginatedWithCompanyAsync(int page, int pageSize, Guid companyId, string? search = null,
        CancellationToken cancellationToken = default);

    Task<Budget?> GetByIdWithCompanyAsync(Guid id, CancellationToken cancellationToken = default);

    Task<int> CountBudgetsByBudgetTypeAndCompanyIdAsync(Guid companyId, BudgetType budgetType,
        CancellationToken cancellationToken);
}