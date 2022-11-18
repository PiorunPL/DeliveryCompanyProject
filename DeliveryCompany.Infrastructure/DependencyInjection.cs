using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Common.Interfaces.Persistance;
using DeliveryCompany.Infrastructure.Authentication;
using DeliveryCompany.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryCompany.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        //var jwtSettings = new JwtSettings();
        //configuration.Bind(JwtSettings.SectionName, jwtSettings);

        //services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}