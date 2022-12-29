using FluentValidation;
using MakeAdsApi.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MakeAdsApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return services.AddMediatR(typeof(DependencyInjection).Assembly);
    }
}
