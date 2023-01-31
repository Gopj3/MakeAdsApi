using System;
using MakeAdsApi.Domain.Entities.Offices;

namespace MakeAdsApi.Domain.Entities.SocialMedias;

public abstract class BaseSocialMediaConfig: BaseEntity
{
    public Guid OfficeId { get; set; }
    
    public Office Office { get; set; }
    public string Title { get; set; }
}