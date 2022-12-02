using System.Text;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Infrastructure.Authentication;
using DeliveryCompany.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DeliveryCompany.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddScoped<IClientRepository, ClientListRepository>();
        services.AddScoped<IAdministratorRepository, AdministratorListRepository>();
        services.AddScoped<ICourierRepository, CourierListRepository>();
        services.AddScoped<IClientOrderRepository, ClientOrderListRepository>();

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

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "DeliveryCompany",
                ValidAudience = "DeliveryCompany",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-secret-key")
                )
            });

        return services;
    }
}