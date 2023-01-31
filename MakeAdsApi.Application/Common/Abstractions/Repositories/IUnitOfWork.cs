using System;
using System.Threading;
using System.Threading.Tasks;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUnitOfWork: IDisposable
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
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}