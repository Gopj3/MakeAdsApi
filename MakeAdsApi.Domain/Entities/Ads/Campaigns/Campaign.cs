using System;
using MakeAdsApi.Domain.Enums;

namespace MakeAdsApi.Domain.Entities.Ads.Campaigns;

public class Campaign: BaseEntity
{
    public string Title { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string SocialMediaReferenceId { get; set; }
    public AvailableSocialMedias SocialMediaPlatform { get; set; }
}