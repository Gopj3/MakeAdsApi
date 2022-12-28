using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Offices;

namespace MakeAdsApi.Domain.Entities.Users;

public class User: BaseEntity
{
    public string Password { get; set; }
    public UserProfile? Profile { get; set; }

    public Office Office { get; set; }
    public Guid OfficeId { get; set; }

    public List<UserRole> UserRoles { get; } = new();
}