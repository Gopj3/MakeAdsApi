using MakeAdsApi.Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class OfficeConfiguration
{
    public static void ConfigureOffice(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Office>()
            .HasOne(o => o.DeltaMediaConfig)
            .WithOne();
        modelBuilder.Entity<Office>()
            .HasOne(o => o.MetaMediaConfig)
            .WithOne();
        modelBuilder.Entity<Office>()
            .HasOne(o => o.SnapChatMediaConfig)
            .WithOne();
        modelBuilder.Entity<Office>()
            .HasOne(x => x.Branding)
            .WithOne();
    }    
}