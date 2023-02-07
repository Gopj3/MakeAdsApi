using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Offices;
using ErrorOr;
using MakeAdsApi.Domain.Entities.Orders;

namespace MakeAdsApi.Domain.Entities.Users;

public class User: BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsPasswordAutomaticGenerated { get; set; }
    public UserProfile? Profile { get; set; }
    public Guid? OfficeId { get; set; }
    public Office? Office { get; set; }
    public List<UserRole> UserRoles { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
}