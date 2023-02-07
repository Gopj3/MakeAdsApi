using System.Collections.Generic;

namespace MakeAdsApi.Domain.Entities.Ads.Creatives;

public class ABCreative: BaseCreative
{
    public List<AbCreativeMedia> AbCreativeMedias { get; set; } = new();
}