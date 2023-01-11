using MakeAdsApi.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MakeAdsApi.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();

        
        return services;
    }
}