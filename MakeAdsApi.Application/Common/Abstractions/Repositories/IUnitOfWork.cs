using System;
using System.Threading;
using System.Threading.Tasks;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; set; }
    IRoleRepository RoleRepository { get; set; }
    IUserProfileRepository UserProfileRepository { get; set; }
    IUserProfileAvatarRepository UserProfileAvatarRepository { get; set; }
    IRetailDataProviderRepository RetailDataProviderRepository { get; set; }
    IFileRepository FileRepository { get; set; }
    ICompanyRepository CompanyRepository { get; set; }
    IOfficeRepository OfficeRepository { get; set; }
    IBudgetRepository BudgetRepository { get; set; }
    IBudgetItemRepository BudgetItemRepository { get; set; }
    IAdvertiseRepository AdvertiseRepository { get; set; }
    IOrderRepository OrderRepository { get; set; }
    IBaseCreativeRepository BaseCreativeRepository { get; set; }
    ISingleCreativeRepository SingleCreativeRepository { get; set; }
    IABCreativeRepository AbCreativeRepository { get; set; }
    ICarouselCreativeRepository CarouselCreativeRepository { get; set; }
    ICarouselCreativeItemRepository CarouselCreativeItemRepository { get; set; }
    IMediaRepository MediaRepository { get; set; }
    IAdSetLocationRepository AdSetLocationRepository { get; set; }
    IAdSetRepository AdSetRepository { get; set; }
    ICampaignRepository CampaignRepository { get; set; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}