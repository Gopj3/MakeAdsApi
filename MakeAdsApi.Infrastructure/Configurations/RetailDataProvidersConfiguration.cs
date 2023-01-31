using MakeAdsApi.Domain.Entities.RetailDataProviders;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class RetailDataProvidersConfiguration
{
    public static void ConfigureRetailDataProviders(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RetailDataProvider>().HasQueryFilter(x => x.DeletedAt == null);
    }
}