using System;
using System.Collections.Generic;
using System.Linq;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class CompaniesAutoCreationConfig
{
    public static void ConfigureCompaniesAutoCreation(this ModelBuilder modelBuilder)
    {
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