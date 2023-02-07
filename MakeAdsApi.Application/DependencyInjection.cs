using FluentValidation;
using MakeAdsApi.Application.Behaviors;
using MakeAdsApi.Application.Common.Abstractions.Services.Users;
using MakeAdsApi.Application.Services.Users;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MakeAdsApi.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient(
            typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)
        );
        services.AddScoped<IUsersAutoCreateService, UsersAutoCreateService>();
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddMediatR(typeof(DependencyInjection).Assembly);
    }
}