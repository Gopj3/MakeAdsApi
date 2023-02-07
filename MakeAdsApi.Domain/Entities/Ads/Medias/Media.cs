using System;
using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Enums.Ads;

namespace MakeAdsApi.Domain.Entities.Ads.Medias;

public class Media: BaseEntity
{
    public Guid FileId { get; set; }
    public File File { get; set; }
    public MediaType Type { get; set; }
}