using System;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;

namespace MakeAdsApi.Infrastructure.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly MakeAdsDbContext _context;
    private bool _disposed = false;

    public IUserRepository UserRepository { get; set; }

    public UnitOfWork(MakeAdsDbContext context)
    {
        _context = context;
        UserRepository = new UserRepository(context);
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