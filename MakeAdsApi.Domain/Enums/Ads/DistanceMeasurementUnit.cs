using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums.Ads;

public class DistanceMeasurementUnit: SmartEnum<DistanceMeasurementUnit, string>
{
    public static readonly DistanceMeasurementUnit Km = new(nameof(Km), nameof(Km).ToLower());
    
    public DistanceMeasurementUnit(string name, string value) : base(name, value)
    {
    }
}