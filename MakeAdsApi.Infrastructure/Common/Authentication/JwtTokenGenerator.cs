using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MakeAdsApi.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace MakeAdsApi.Infrastructure.Common.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        SigningCredentials signingCredentials = new SigningCredentials
        (
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")), 
            SecurityAlgorithms.HmacSha256
        );

        public string GenerateToken(Guid userId, string email)
        {
            DateTime now = DateTime.UtcNow.AddHours(24);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Exp, now.ToString(CultureInfo.InvariantCulture))
            };

            var token = new JwtSecurityToken(
                issuer: "MakeAdsApi",
                audience: "MakeAdsApi",
                claims: claims,
                expires: now,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}