using System;
using MakeAdsApi.Domain.Entities.Ads.Medias;

namespace MakeAdsApi.Domain.Entities.Ads.Creatives;

public class CarouselCreativeItem: BaseEntity
{
    public string? Headline { get; set; }
    public string? Link { get; set; }
    public string? Caption { get; set; }
    public Guid MediaId { get; set; }
    public Media Media { get; set; }
    public Guid CarouselCreativeId { get; set; }
    public CarouselCreative CarouselCreative { get; set; }
}