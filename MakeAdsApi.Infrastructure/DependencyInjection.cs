using MakeAdsApi.Application.Common.Interfaces.Authentication;
using MakeAdsApi.Infrastructure.Common.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MakeAdsApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager builderConfiguration
        )
        {
            services.Configure<JwtSettings>(builderConfiguration.GetSection("JwtSettings"));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
