using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IBudgetRepository : IGenericRepository<Budget>
{
    Task<PagedList<Budget>> GetPaginatedWithCompanyAsync(int page, int pageSize, string? search = null,
        CancellationToken cancellationToken = default);
}