using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MakeAdsApi.Domain.Entities.Offices;

namespace MakeAdsApi.Domain.Entities.Users;

public class User: BaseEntity
{
    public UserProfile? Profile { get; set; }
    public Guid OfficeId { get; set; }
    public Office Office { get; set; }
    public List<UserRole> UserRoles { get; } = new();
    public string Password { get; set; }
    
    [JsonIgnore]
    public string HasPassword { get; set; }
}