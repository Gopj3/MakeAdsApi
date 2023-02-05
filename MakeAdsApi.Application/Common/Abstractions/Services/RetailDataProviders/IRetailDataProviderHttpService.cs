using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.RetailProviders.Common.Models;

namespace MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;

public interface IRetailDataProviderHttpService
{
    Task<RetailDataPropertyApiResponse?> GetRetailPropertyDataAsync(string url, string externalCompanyId,
        string propertyId, CancellationToken cancellationToken = default);
}