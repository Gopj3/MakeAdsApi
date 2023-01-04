using System;

namespace MakeAdsApi.Application.Common.Abstractions.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string email);
}