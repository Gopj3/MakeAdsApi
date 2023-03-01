using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Ads;
using MakeAdsApi.Domain.Entities.Ads.AdSets;
using MakeAdsApi.Domain.Entities.Ads.Campaigns;
using MakeAdsApi.Domain.Entities.Ads.Creatives;
using MakeAdsApi.Domain.Entities.Ads.Medias;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Entities.Files.MediaLibrary;
using MakeAdsApi.Domain.Entities.Offices;
using MakeAdsApi.Domain.Entities.Orders;
using MakeAdsApi.Domain.Entities.Properties;
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
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<BudgetItem> BudgetItems { get; set; }
    public DbSet<BaseCreative> BaseCreatives { get; set; }
    public DbSet<SingleCreative> SingleCreatives { get; set; }
    public DbSet<ABCreative> AbCreatives { get; set; }
    public DbSet<CarouselCreative> CarouselCreatives { get; set; }
    public DbSet<CarouselCreativeItem> ACarouselCreativeItems { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<AdSet> AdSets { get; set; }
    public DbSet<AdSetLocation> AdSetLocations { get; set; }
    public DbSet<Advertise> Advertises { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyUser> PropertyUsers { get; set; }

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
        modelBuilder.ConfigureCreatives();
        modelBuilder.ConfigureMedias();
        modelBuilder.ConfigureCampaigns();
        modelBuilder.ConfigureAdSets();
        modelBuilder.ConfigureAdvertises();
        modelBuilder.ConfigureProperties();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.TimeStampsAndSoftDeletion();
        return base.SaveChangesAsync(cancellationToken);
    }
}