using System;
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
    public UnitOfWork(MakeAdsDbContext context)
    {
        _context = context;
        UserRepository = new UserRepository(context);
        RoleRepository = new RoleRepository(context);
        UserProfileRepository = new UserProfileRepository(context);
        UserProfileAvatarRepository = new UserProfileAvatarRepository(context);
        RetailDataProviderRepository = new RetailDataProviderRepository(context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
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