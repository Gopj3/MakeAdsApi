using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

internal static class CompaniesConfiguration
{
    public static void ConfigureCompanies(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasOne(c => c.RetailDataProvider)
            .WithMany(rdp => rdp.Companies);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.AutoCreationConfigs)
            .WithOne(cac => cac.Company);

        modelBuilder.Entity<Company>()
            .HasOne(x => x.Branding)
            .WithOne();
        
        modelBuilder.Entity<Company>()
            .HasMany<Office>(x => x.Offices)
            .WithOne(x => x.Company);
    }
}