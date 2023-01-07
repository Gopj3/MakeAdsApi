using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Infrastructure.Common.Authentication;

public class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : User
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 12);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        var isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

        if (isValid && !BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, 12))
        {
            return true;
        }

        return false;
    }
}