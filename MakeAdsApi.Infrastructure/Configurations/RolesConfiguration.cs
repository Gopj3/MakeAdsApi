using System;
using MakeAdsApi.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

internal static class RolesConfiguration
{
    public static void ConfigureRole(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role(
                id: Guid.Parse("59508398-5e83-4ef5-9774-24f8e6f0d4ec"),
                title: "Admin"
            ),
            new Role(
                id: Guid.Parse("69508328-5e83-4ef5-9774-24f8e6f0d4ec"),
                title: "User"
            )
        );
    }
}