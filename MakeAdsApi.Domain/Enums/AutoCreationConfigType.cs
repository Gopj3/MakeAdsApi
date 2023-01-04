using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums;

public class AutoCreationConfigType: SmartEnum<AutoCreationConfigType, string>
{
    public static readonly AutoCreationConfigType PropertySold = new (nameof(PropertySold), nameof(PropertySold).ToLower());
    public static readonly AutoCreationConfigType RegularAutoCreation = new (nameof(RegularAutoCreation), nameof(RegularAutoCreation).ToLower());

    public AutoCreationConfigType(string name, string value) : base(name, value)
    {
    }
}
