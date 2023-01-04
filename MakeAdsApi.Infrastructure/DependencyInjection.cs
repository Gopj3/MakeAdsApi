using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Infrastructure.Common.Authentication;
using MakeAdsApi.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MakeAdsApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services,
            ConfigurationManager builderConfiguration)
        {
            services.Configure<JwtSettings>(builderConfiguration.GetSection("JwtSettings"));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
