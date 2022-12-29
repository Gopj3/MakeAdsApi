using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using MakeAdsApi.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MakeAdsApi.Infrastructure.Common.Authentication;

public class JwtTokenValidator : IJwtTokenValidator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenValidator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public Guid? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);
            
            var jwtToken = (JwtSecurityToken) validatedToken;
            
            return Guid.Parse(jwtToken.Claims.First(x => x.Type == nameof(JwtRegisteredClaimNames.Sub)).Value);
        }
        catch
        {
            return null;
        }
    }
}