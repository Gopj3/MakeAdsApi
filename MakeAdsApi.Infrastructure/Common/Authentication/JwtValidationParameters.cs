using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MakeAdsApi.Infrastructure.Common.Authentication;

public static class JwtValidationParameters
{
    public static TokenValidationParameters GetValidationParameters(IConfigurationSection section)
    {
        byte[] key = Encoding.ASCII.GetBytes(section["Secret"] ?? string.Empty);
        
        return GetParameters(key, section["Issuer"]);
    }

    private static TokenValidationParameters GetParameters(byte[] key, string? issuer)
    {
        if (issuer is null) 
            throw new ArgumentNullException($"Invalid JWT settings. Missed: {0}",nameof(issuer));
        
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
    }
}