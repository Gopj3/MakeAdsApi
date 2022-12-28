using System;
using MakeAdsApi.Application.Common.Interfaces.Authentication;

namespace MakeAdsApi.Infrastructure.Common.Authentication;

public class JwtTokenValidator: IJwtTokenValidator
{
    public Guid? ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}