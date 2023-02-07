namespace MakeAdsApi.Domain.Entities.Ads.Creatives;

public abstract class BaseCreative: BaseEntity
{
    public string? Headline { get; set; }
    public string? Type { get; set; }
    public string? Link { get; set; }
    public string? Description { get; set; }
    public string? Caption { get; set; }
    public string? SocialMediaReference { get; set; }
}