using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.RetailDataProviders;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IRetailDataProviderRepository : IGenericRepository<RetailDataProvider>
{
}