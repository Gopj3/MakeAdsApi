using System;

namespace MakeAdsApi.Application.Common.Interfaces.Authentication;

public interface IJwtTokenValidator
{
    Guid? ValidateToken(string token);
}