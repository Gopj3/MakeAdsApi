using System;
using System.Collections.Generic;

namespace MakeAdsApi.Domain.Entities.Users;

public class Role: BaseEntity
{
    public Role(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
    public string Title { get; set; }
    public List<UserRole> UserRoles { get; set; } = new();
}