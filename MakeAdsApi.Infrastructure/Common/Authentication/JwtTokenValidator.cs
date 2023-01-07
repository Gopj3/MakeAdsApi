using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
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
        try
        {
            tokenHandler.ValidateToken(
                token,
                JwtValidationParameters.GetValidationParameters(_jwtSettings),
                out var validatedToken
            );
            var jwtToken = (JwtSecurityToken)validatedToken;

            return Guid.Parse(jwtToken.Claims.First(x => x.Type == nameof(JwtRegisteredClaimNames.Sub)).Value);
        }
        catch
        {
            return null;
        }
    }
}