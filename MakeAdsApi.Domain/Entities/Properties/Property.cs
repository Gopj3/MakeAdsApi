using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Orders;

namespace MakeAdsApi.Domain.Entities.Properties;

public class Property: BaseEntity
{
    public string PropertyId { get; set; }
    public string Address { get; set; }
    public bool IsSold { get; set; }
    public List<Order> Orders { get; set; } = new();
    public List<PropertyUser> Users { get; set; } = new();
}