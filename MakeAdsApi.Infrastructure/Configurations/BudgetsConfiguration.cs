using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class BudgetsConfiguration
{
    public static void ConfigureBudgets(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>().ToTable("Budgets");
        modelBuilder.Entity<Budget>().HasQueryFilter(x => x.DeletedAt == null);
        
        modelBuilder.Entity<Budget>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Budget>()
            .HasMany(x => x.BudgetItems)
            .WithOne(x => x.Budget);
        modelBuilder.Entity<Budget>()
            .HasOne(x => x.Company)
            .WithMany(x => x.Budgets);
        modelBuilder.Entity<Budget>()
            .Property(x => x.Type)
            .IsRequired()
            .HasConversion(
                x => x.Value,
                x => BudgetType.FromValue(x)
            );
    }
}