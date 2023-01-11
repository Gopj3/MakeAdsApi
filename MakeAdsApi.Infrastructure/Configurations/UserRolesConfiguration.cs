using System;
using MakeAdsApi.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

internal static class UserRoleConfiguration
{
    public static void ConfigureUserRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles);

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole
            {
                Id = Guid.Parse("85231998-5e83-4ef5-9774-24f8e6f0d4ec"),
                UserId = Guid.Parse("49508398-5e83-4ef5-9774-24f8e6f0d4ec"),
                RoleId = Guid.Parse("59508398-5e83-4ef5-9774-24f8e6f0d4ec")
            }
        );
    }
}