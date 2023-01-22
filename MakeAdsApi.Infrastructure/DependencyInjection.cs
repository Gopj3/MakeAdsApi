using MakeAdsApi.Application.Common.Abstractions.Services.AWS;
using MakeAdsApi.Infrastructure.Services.AWS;

namespace MakeAdsApi.Infrastructure;

using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using Domain.Entities.Users;
using Common.Authentication;
using Common.AWS;
using Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.Configure<JwtSettings>(builderConfiguration.GetSection(nameof(JwtSettings)));
        services.Configure<AwsSettings>(builderConfiguration.GetSection(nameof(AwsSettings)));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddSingleton<IAwsS3Service, AwsS3Service>();
    }
}