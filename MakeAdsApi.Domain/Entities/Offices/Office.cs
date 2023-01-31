using System;
using System.Collections.Generic;
using ErrorOr;
using MakeAdsApi.Domain.Entities.Brandings;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Entities.SocialMedias;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Domain.Entities.Offices;

public class Office: BaseEntity
{
    public string Title { get; set; }
    public string ExternalId { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    public List<User> Users { get; set; } = new ();
    public DeltaMediaConfig? DeltaMediaConfig { get; set; } = null;
    public MetaMediaConfig? MetaMediaConfig { get; set; } = null;
    public SnapChatMediaConfig? SnapChatMediaConfig { get; set; } = null;
    public Guid? BrandingId { get; set; } = null;
    public Branding? Branding { get; set; } = null;

    public Office(string title, string externalId, Guid companyId)
    {
        Id = Guid.NewGuid();
        Title = title;
        ExternalId = externalId;
        CompanyId = companyId;
    }

    public void Update(string title, string externalId, Guid companyId)
    {
        Title = title;
        ExternalId = externalId;
        CompanyId = companyId;
    }
}