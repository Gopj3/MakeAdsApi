namespace MakeAdsApi.Infrastructure;

using MakeAdsApi.Application.Common.Abstractions.Helpers;
using MakeAdsApi.Application.Common.Abstractions.Jobs;
using MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;
using Helpers;
using Services.RetailDataProviders;
using Hangfire;
using MakeAdsApi.Application.Common.Abstractions.Services.AWS;
using Jobs;
using Services.AWS;
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
        services.AddScoped<IUpdatePreSignedUrlsService, UpdatePreSignedUrlsService>();
        services.AddHttpClient<IRetailDataProviderHttpService, RetailDataProviderHttpService>();
        services.AddHttpClient<IFilesHelper, FilesHelper>();
        services.AddScoped<IFilesHelper, FilesHelper>();
        
        services.AddHangfire(x => { x.UseSqlServerStorage(builderConfiguration.GetConnectionString("HangFireDb")); });
        services.AddHangfireServer();
    }
}