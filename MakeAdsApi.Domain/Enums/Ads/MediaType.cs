using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums.Ads;

public class MediaType : SmartEnum<MediaType, string>
{
    public static readonly MediaType Image = new(nameof(Image), nameof(Image).ToLower());

    public static readonly MediaType Video = new(nameof(Video), nameof(Video).ToLower());

    public MediaType(string name, string value) : base(name, value)
    {
    }
}