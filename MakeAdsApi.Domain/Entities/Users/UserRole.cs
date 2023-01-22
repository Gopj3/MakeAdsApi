using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeAdsApi.Domain.Entities.Users;

public class UserRole: BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public static List<UserRole>? Create(Guid userId, List<Role> roles)
    {
        if (roles.Any())
        {
            return roles.Select(el => new UserRole
            {
                UserId = userId,
                RoleId = el.Id
            }).ToList();
        }

        return null;
    }
    
    public static UserRole Create(Guid userId, Role role)
    {
        return new UserRole
        {
            UserId = userId,
            RoleId = role.Id
        };
    }
}