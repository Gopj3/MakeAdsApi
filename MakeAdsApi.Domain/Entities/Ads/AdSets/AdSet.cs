using System.Collections.Generic;

namespace MakeAdsApi.Domain.Entities.Ads.AdSets;

public class AdSet: BaseEntity
{
    public string Title { get; set; }
    public string SocialMediaReferenceId { get; set; }
    public List<AdSetLocation> AdSetLocations { get; set; } = new();
}