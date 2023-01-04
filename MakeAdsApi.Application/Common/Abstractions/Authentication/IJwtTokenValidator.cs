using System;

namespace MakeAdsApi.Application.Common.Abstractions.Authentication;

public interface IJwtTokenValidator
{
    Guid? ValidateToken(string token);
}