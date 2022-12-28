using System.Collections.Generic;

namespace MakeAdsApi.Domain.Entities.Users;

public class Role: BaseEntity
{
    public string Title { get; set; }
    public List<UserRole> UserRoles { get; set; } = new();
}