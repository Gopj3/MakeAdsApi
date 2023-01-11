using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Domain.Entities.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static System.Security.Claims.ClaimsIdentity;

namespace MakeAdsApi.Infrastructure.Common.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(User user)
        {
            SigningCredentials signingCredentials = new
            (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256
            );

            DateTime now = DateTime.UtcNow.AddHours(24);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Exp, now.ToString(CultureInfo.InvariantCulture)),
                new(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            };

            claims.AddRange(user.UserRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Title)));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                expires: now,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}