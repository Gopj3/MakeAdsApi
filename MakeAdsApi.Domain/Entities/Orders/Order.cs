using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Ads;
using MakeAdsApi.Domain.Entities.Properties;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Domain.Entities.Orders;

public class Order: BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid PropertyId { get; set; }
    public Property Property { get; set; }
    public List<Advertise> Advertises { get; set; } = new ();
}