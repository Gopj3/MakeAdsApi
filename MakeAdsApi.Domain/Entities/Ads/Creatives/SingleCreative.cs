using System;
using MakeAdsApi.Domain.Entities.Ads.Medias;

namespace MakeAdsApi.Domain.Entities.Ads.Creatives;

public class SingleCreative: BaseCreative
{
    public Guid MediaId { get; set; }
    public Media Media { get; set; }
}