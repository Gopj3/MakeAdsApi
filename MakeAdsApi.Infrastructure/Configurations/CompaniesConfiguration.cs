using System;
using System.Collections.Generic;
using System.Linq;
using MakeAdsApi.Domain.Entities.Brandings;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class CompaniesConfiguration
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

        modelBuilder.Entity<CompanyAutoCreationConfig>()
            .Property(cacc => cacc.AvailableSocialMedias)
            .IsRequired()
            .HasConversion(
                p =>
                    p.Select(op => op.Value.ToString()).ToList()
                        .Aggregate((a, b) => a + ',' + b),
                p => p.Split(',', StringSplitOptions.None)
                    .ToList().Select(sp => AvailableSocialMedias.FromValue(sp)).ToList(),
                new ValueComparer<List<AvailableSocialMedias>>(
                    (a, b) => a.SequenceEqual(b),
                    c => c.Aggregate(
                        0, (a, v) => HashCode.Combine(a, v.Value.GetHashCode())
                    ),
                    c => c.ToList()));
        
        modelBuilder.Entity<CompanyAutoCreationConfig>()
            .Property(x => x.Type)
            .HasConversion(
                x => x.Value,
                x => AutoCreationConfigType.FromValue(x)
            );
    }
}