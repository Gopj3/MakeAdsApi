using System;
using MakeAdsApi.Domain.Entities.Ads.AdSets;
using MakeAdsApi.Domain.Entities.Ads.Campaigns;
using MakeAdsApi.Domain.Entities.Ads.Creatives;
using MakeAdsApi.Domain.Entities.Orders;
using MakeAdsApi.Domain.Enums;
using MakeAdsApi.Domain.Enums.Ads;

namespace MakeAdsApi.Domain.Entities.Ads;

public class Advertise: BaseEntity
{
    public Guid CreativeId { get; set; }
    public BaseCreative Creative { get; set; }
    public Guid AdSetId { get; set; }
    public AdSet AdSet { get; set; }
    public Guid CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public AvailableSocialMedias SocialMediaPlatform { get; set; }
    public InternalStatus InternalStatus { get; set; }
}