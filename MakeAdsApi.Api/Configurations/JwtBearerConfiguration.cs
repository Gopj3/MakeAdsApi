using MakeAdsApi.Infrastructure.Common.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MakeAdsApi.Api.Configurations;

public static class JwtBearerConfiguration
{
    public static void ConfigureJwtBearer(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        var jwtSection = configurationManager.GetSection("JwtSettings");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                options.TokenValidationParameters = JwtValidationParameters.GetValidationParameters(jwtSection)
            );
    }
}