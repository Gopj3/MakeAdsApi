namespace MakeAdsApi.Contracts.Admin.RetailDataProvider;

public record RetailDataProviderRequest(
    string Title,
    string? FetchPropertyDataUrl,
    string? UpdatePropertyDataUrl,
    string? FetchUserDataUrl,
    string? UpdateUserDataUrl
);