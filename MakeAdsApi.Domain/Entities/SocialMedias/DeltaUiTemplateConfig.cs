using System;
using System.ComponentModel.DataAnnotations;

namespace MakeAdsApi.Domain.Entities.SocialMedias;

public class DeltaUiTemplateConfig: BaseEntity
{
    public string TemplateTitle { get; set; }
    public string TemplateId { get; set; }

    public Guid DeltaMediaConfigId { get; set; }
    public DeltaMediaConfig DeltaMediaConfig { get; set; }
}