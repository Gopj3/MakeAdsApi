using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Entities.Files.MediaLibrary;
using MakeAdsApi.Domain.Entities.Offices;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Entities.RetailDataProviders;
using MakeAdsApi.Domain.Entities.SocialMedias;
using MakeAdsApi.Infrastructure.Configurations;
using MakeAdsApi.Infrastructure.Extensions;
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
    public DbSet<File> Files { get; set; }
    public DbSet<MediaLibraryImage> MediaLibraryImages { get; set; }
    public DbSet<MediaLibraryVideo> MediaLibraryVideos { get; set; }
    public DbSet<UserProfileAvatar> UserProfileAvatars { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureRole();
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureCompanies();
        modelBuilder.ConfigureCompaniesAutoCreation();
        modelBuilder.ConfigureOffice();
        modelBuilder.ConfigureUserRoles();
        modelBuilder.ConfigureMediaConfigs();
        modelBuilder.ConfigureMediaLibrary();
        modelBuilder.ConfigureRetailDataProviders();
        modelBuilder.ConfigureBudgets();
        modelBuilder.ConfigureBudgetItems();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.TimeStampsAndSoftDeletion();
        return base.SaveChangesAsync(cancellationToken);
    }
}