using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Infrastructure.Common.Authentication;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class UsersConfiguration
{
    public static void ConfigureUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(up => up.User);

        modelBuilder.Entity<User>()
            .HasOne(x => x.Office)
            .WithMany(off => off.Users);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserRoles)
            .WithOne(r => r.User);
        
        modelBuilder.Entity<User>()
            .HasData(new User
            {
                Id = Guid.Parse("49508398-5e83-4ef5-9774-24f8e6f0d4ec"),
                Email = "admin@admin-nordic.com",
                Password = (new PasswordHasher<User>()).HashPassword("nordicPass123")
            });
    }
}