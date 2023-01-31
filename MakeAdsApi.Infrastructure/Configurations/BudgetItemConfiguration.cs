using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class BudgetItemConfiguration
{
    public static void ConfigureBudgetItems(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BudgetItem>().ToTable("BudgetItems");
        modelBuilder.Entity<BudgetItem>()
            .Property(x => x.Type)
            .IsRequired()
            .HasConversion(
                x => x.Value,
                x => BudgetItemType.FromValue(x)
            );
    }
}