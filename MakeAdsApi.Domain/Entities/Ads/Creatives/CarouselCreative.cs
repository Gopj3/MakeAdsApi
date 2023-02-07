using System.Collections.Generic;

namespace MakeAdsApi.Domain.Entities.Ads.Creatives;

public class CarouselCreative: BaseCreative
{
    public List<CarouselCreativeItem> Items { get; set; }
}