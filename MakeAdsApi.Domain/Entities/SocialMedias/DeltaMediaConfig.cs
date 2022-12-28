using System.Collections.Generic;

namespace MakeAdsApi.Domain.Entities.SocialMedias;

public class DeltaMediaConfig: BaseSocialMediaConfig
{
    public string ClientId { get; set; }
    public List<DeltaUiTemplateConfig> DeltaUiTemplateConfigs { get; set; } = new();
}