using System;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;

namespace MakeAdsApi.Infrastructure.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly MakeAdsDbContext _context;
    private bool _disposed;

    public IUserRepository UserRepository { get; set; }
    public IRoleRepository RoleRepository { get; set; }
    public IUserProfileRepository UserProfileRepository { get; set; }
    public IUserProfileAvatarRepository UserProfileAvatarRepository { get; set; }
    public IRetailDataProviderRepository RetailDataProviderRepository { get; set; }
    public IFileRepository FileRepository { get; set; }
    public ICompanyRepository CompanyRepository { get; set; }
    public IOfficeRepository OfficeRepository { get; set; }
    public IBudgetRepository BudgetRepository { get; set; }
    public IBudgetItemRepository BudgetItemRepository { get; set; }

    public UnitOfWork(MakeAdsDbContext context)
    {
        _context = context;
        UserRepository = new UserRepository(context);
        RoleRepository = new RoleRepository(context);
        UserProfileRepository = new UserProfileRepository(context);
        UserProfileAvatarRepository = new UserProfileAvatarRepository(context);
        RetailDataProviderRepository = new RetailDataProviderRepository(context);
        FileRepository = new FileRepository(context);
        CompanyRepository = new CompanyRepository(context);
        OfficeRepository = new OfficeRepository(context);
        BudgetRepository = new BudgetRepository(context);
        BudgetItemRepository = new BudgetItemRepository(context);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }
}