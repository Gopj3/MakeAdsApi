using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums.Ads;

public class InternalStatus : SmartEnum<InternalStatus, string>
{
    public static readonly InternalStatus Pending = new(nameof(Pending), nameof(Pending).ToLower());
    public static readonly InternalStatus Paused = new(nameof(Paused), nameof(Paused).ToLower());
    public static readonly InternalStatus Active = new(nameof(Active), nameof(Active).ToLower());

    public static readonly InternalStatus PendingFacebookCreation =
        new(nameof(PendingFacebookCreation), nameof(PendingFacebookCreation).ToLower());

    public static readonly InternalStatus PendingSnapChatCreation =
        new(nameof(PendingSnapChatCreation), nameof(PendingSnapChatCreation).ToLower());

    public static readonly InternalStatus PendingDeltaCreation =
        new(nameof(PendingDeltaCreation), nameof(PendingDeltaCreation).ToLower());

    public InternalStatus(string name, string value) : base(name, value)
    {
    }
}