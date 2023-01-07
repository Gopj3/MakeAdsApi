using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Authentication;

public interface IPasswordHasher<TUser> where TUser: User
{
    string HashPassword(string password);
    
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}