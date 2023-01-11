using System;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}