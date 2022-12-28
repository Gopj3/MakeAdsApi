namespace MakeAdsApi.Domain.Entities.SocialMedias;

public class SnapChatMediaConfig: BaseSocialMediaConfig
{
    public string AdAccountId { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}