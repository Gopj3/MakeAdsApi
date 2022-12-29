using MakeAdsApi.Api.Middlewares;

namespace MakeAdsApi.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        return services.AddTransient<ExceptionHandlingMiddleware>();
    }
}