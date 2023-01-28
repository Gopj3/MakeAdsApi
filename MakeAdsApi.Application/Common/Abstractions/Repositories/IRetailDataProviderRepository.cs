using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.RetailDataProviders;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IRetailDataProviderRepository : IGenericRepository<RetailDataProvider>
{
    Task<PagedList<RetailDataProvider>> GetPaginatedWithSearchAsync(int page, int pageSize, string? search = null,
        CancellationToken cancellationToken = default);
}