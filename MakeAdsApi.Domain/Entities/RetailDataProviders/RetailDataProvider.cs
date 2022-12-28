using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Companies;

namespace MakeAdsApi.Domain.Entities.RetailDataProviders;

public class RetailDataProvider : BaseEntity
{
    public string? FetchPropertyDataUrl { get; set; } = null;
    public string? UpdatePropertyDataUrl { get; set; } = null;
    public string? FetchUserDataUrl { get; set; } = null;
    public string? UpdateUserDataUrl { get; set; } = null;

    public List<Company> Companies { get; set; } = new();
}