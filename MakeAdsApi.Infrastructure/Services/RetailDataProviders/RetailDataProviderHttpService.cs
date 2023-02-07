using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;
using MakeAdsApi.Application.RetailProviders.Common.Models;

namespace MakeAdsApi.Infrastructure.Services.RetailDataProviders;

public class RetailDataProviderHttpService : IRetailDataProviderHttpService
{
    private readonly HttpClient _httpClient;

    public RetailDataProviderHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RetailDataPropertyApiResponse?> GetRetailPropertyDataAsync(
        string url,
        string externalCompanyId,
        string propertyId,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<RetailDataPropertyApiResponse>(
                $"{url}/{externalCompanyId}-{propertyId}", cancellationToken
            );
        }
        catch (Exception e)
        {
            return null;
        }
    }
}