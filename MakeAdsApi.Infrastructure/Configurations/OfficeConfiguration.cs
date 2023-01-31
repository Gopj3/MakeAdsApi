using MakeAdsApi.Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

internal static class OfficeConfiguration
{
    public static void ConfigureOffice(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Office>()
            .HasOne(o => o.DeltaMediaConfig)
            .WithOne(x => x.Office);
        modelBuilder.Entity<Office>()
            .HasOne(o => o.MetaMediaConfig)
            .WithOne(x => x.Office);
        modelBuilder.Entity<Office>()
            .HasOne(o => o.SnapChatMediaConfig)
            .WithOne(x => x.Office);
        modelBuilder.Entity<Office>()
            .HasOne(x => x.Branding)
            .WithOne();
    }    
}