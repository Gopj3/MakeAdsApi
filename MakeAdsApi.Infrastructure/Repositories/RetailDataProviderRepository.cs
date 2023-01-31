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
}