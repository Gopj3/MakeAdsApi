using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.RetailDataProviders;

namespace MakeAdsApi.Infrastructure.Repositories;

public class RetailDataProviderRepository: GenericRepository<RetailDataProvider>, IRetailDataProviderRepository
{
    public RetailDataProviderRepository(MakeAdsDbContext context) : base(context)
    {
    }

    public Task<PagedList<RetailDataProvider>> GetPaginatedWithSearchAsync(int page, int pageSize, string? search = null,
        CancellationToken cancellationToken = default)
    {
        var query = Context.RetailDataProviders.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Title.Contains(search));
        }

        return PagedList<RetailDataProvider>.ToPagedList(query, page, pageSize);
    }
}