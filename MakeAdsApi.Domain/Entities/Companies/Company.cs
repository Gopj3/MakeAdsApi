using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Brandings;
using MakeAdsApi.Domain.Entities.Offices;
using MakeAdsApi.Domain.Entities.RetailDataProviders;

namespace MakeAdsApi.Domain.Entities.Companies;

public class Company: BaseEntity
{
    public string Title { get; set; }
    public string ExternalId { get; set; }
    public Guid RetailDataProviderId { get; set; }
    public RetailDataProvider RetailDataProvider { get; set; }
    public List<CompanyAutoCreationConfig> AutoCreationConfigs { get; set; } = new();
    public List<Office> Offices { get; set; } = new();
    public Guid? BrandingId { get; set; } = null;
    public Branding? Branding { get; set; } = null;
}