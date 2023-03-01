using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using Microsoft.Extensions.Logging;

namespace MakeAdsApi.Infrastructure.Services.RetailDataProviders;

public class RetailDataProviderHttpService : IRetailDataProviderHttpService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RetailDataProviderHttpService> _logger;

    public RetailDataProviderHttpService(HttpClient httpClient, ILogger<RetailDataProviderHttpService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
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
            _logger.LogError("Unable to get response from retail data provider service. Message :" + e.Message);
            return null;
        }
    }
}