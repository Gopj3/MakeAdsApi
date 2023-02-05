using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Companies;

namespace MakeAdsApi.Domain.Entities.RetailDataProviders;

public class RetailDataProvider : BaseEntity
{
    public string Title { get; set; }
    public string? FetchPropertyDataUrl { get; set; } = null;
    public string? UpdatePropertyDataUrl { get; set; } = null;
    public string? FetchUserDataUrl { get; set; } = null;
    public string? UpdateUserDataUrl { get; set; } = null;
    public List<Company> Companies { get; set; } = new();

    public void Update(
        string title,
        string? fetchPropertyDataUrl,
        string? updatePropertyDataUrl,
        string? fetchUserDataUrl,
        string? updateUserDataUrl
        )
    {
        Title = title;
        FetchPropertyDataUrl = fetchPropertyDataUrl;
        UpdatePropertyDataUrl = updatePropertyDataUrl;
        FetchUserDataUrl = fetchUserDataUrl;
        UpdateUserDataUrl = updateUserDataUrl;
    }
}