using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Brandings;
using MakeAdsApi.Domain.Entities.SocialMedias;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Domain.Entities.Offices;

public class Office: BaseEntity
{
    public string Title { get; set; }
    public string ExternalId { get; set; }
    public List<User> Users { get; set; } = new ();

    public Guid? DeltaMediaConfigId { get; set; } = null;
    public DeltaMediaConfig? DeltaMediaConfig { get; set; } = null;

    public Guid? MetaMediaConfigId { get; set; } = null;
    public MetaMediaConfig? MetaMediaConfig { get; set; } = null;

    public Guid? SnapChatMediaConfigId { get; set; } = null;
    public SnapChatMediaConfig? SnapChatMediaConfig { get; set; } = null;
    
    public Guid? BrandingId { get; set; } = null;
    public Branding? Branding { get; set; } = null;
}