namespace MakeAdsApi.Domain.Entities.Brandings;

public class Branding : BaseEntity
{
    public string BrandingTitle { get; set; }
    public string BrandingLogo { get; set; }
    public string Type { get; set; }
}