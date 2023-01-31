using MakeAdsApi.Domain.Entities.Budgets;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class BudgetsConfiguration
{
    public static void ConfigureBudgets(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>().ToTable("Budgets");
        modelBuilder.Entity<Budget>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Budget>()
            .HasMany(x => x.BudgetItems)
            .WithOne(x => x.Budget);

        modelBuilder.Entity<Budget>()
            .HasOne(x => x.Company)
            .WithMany(x => x.Budgets);
    }
}