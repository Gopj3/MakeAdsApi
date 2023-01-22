using System;
using System.Threading.Tasks;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUnitOfWork: IDisposable
{
    IUserRepository UserRepository { get; set; }
    IRoleRepository RoleRepository { get; set; }
    
    Task SaveChangesAsync();
}