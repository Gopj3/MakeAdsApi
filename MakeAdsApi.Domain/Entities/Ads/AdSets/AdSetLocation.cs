using System;
using MakeAdsApi.Domain.Enums.Ads;

namespace MakeAdsApi.Domain.Entities.Ads.AdSets;

public class AdSetLocation: BaseEntity
{
    public DistanceMeasurementUnit Unit { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public int Radius { get; set; }
    public Guid AdSetId { get; set; }
    public AdSet AdSet { get; set; }
}