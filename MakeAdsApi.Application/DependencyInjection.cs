using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MakeAdsApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddMediatR(typeof(DependencyInjection).Assembly);
    }
}