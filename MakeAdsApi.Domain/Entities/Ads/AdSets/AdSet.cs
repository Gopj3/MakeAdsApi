using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums;

namespace MakeAdsApi.Domain.Entities.Ads.AdSets;

public class AdSet: BaseEntity
{
    public string Title { get; set; }
    public string SocialMediaReferenceId { get; set; }
    public AvailableSocialMedias SocialMediaPlatform { get; set; }
    
    public Guid BudgetId { get; set; }
    public Budget Budget { get; set; }
    public List<AdSetLocation> AdSetLocations { get; set; } = new();
}