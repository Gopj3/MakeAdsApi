using System;
using MakeAdsApi.Domain.Entities.Ads.Medias;

namespace MakeAdsApi.Domain.Entities.Ads.Creatives;

public class AbCreativeMedia: BaseEntity
{
    public Guid AbCreativeId { get; set; }
    public ABCreative AbCreative { get; set; }
    public Guid MediaId { get; set; }
    public Media Media { get; set; }
}