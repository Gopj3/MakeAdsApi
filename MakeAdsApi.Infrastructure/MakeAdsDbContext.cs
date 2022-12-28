using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Entities.Offices;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Entities.RetailDataProviders;
using MakeAdsApi.Domain.Entities.SocialMedias;
using MakeAdsApi.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure;

public class MakeAdsDbContext : DbContext
{
    public MakeAdsDbContext(DbContextOptions<MakeAdsDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyAutoCreationConfig> CompanyAutoCreationConfigs { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<RetailDataProvider> RetailDataProviders { get; set; }
    public DbSet<MetaMediaConfig> MetaMediaConfigs { get; set; }
    public DbSet<DeltaMediaConfig> DeltaMediaConfigs { get; set; }
    public DbSet<DeltaUiTemplateConfig> DeltaUiTemplateConfigs { get; set; }
    public DbSet<SnapChatMediaConfig> SnapChatMediaConfigs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureCompanies();
        modelBuilder.ConfigureOffice();
        modelBuilder.ConfigureUserRoles();
        modelBuilder.ConfigureMediaConfigs();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            var entity = entityEntry.Entity as BaseEntity;
            if (entity == null) continue;
            
            entity.UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}