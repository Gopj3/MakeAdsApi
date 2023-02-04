using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums;

public class AvailableSocialMedias : SmartEnum<AvailableSocialMedias, string>
{
    public static readonly AvailableSocialMedias Facebook = new(nameof(Facebook).ToLower(), nameof(Facebook).ToLower());
    public static readonly AvailableSocialMedias Delta = new(nameof(Delta).ToLower(), nameof(Delta).ToLower());
    public static readonly AvailableSocialMedias SnapChat = new(nameof(SnapChat).ToLower(), nameof(SnapChat).ToLower());
    public static readonly AvailableSocialMedias LinkedIn = new(nameof(LinkedIn).ToLower(), nameof(LinkedIn).ToLower());

    public AvailableSocialMedias(string name, string value) : base(name, value)
    {
    }
}