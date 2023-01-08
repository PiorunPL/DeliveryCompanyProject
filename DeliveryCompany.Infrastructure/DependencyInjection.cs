using System.Text;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Infrastructure.Authentication;
using DeliveryCompany.Infrastructure.Persistence;
using DeliveryCompany.Infrastructure.Persistence.ClientOrders;
using DeliveryCompany.Infrastructure.Persistence.ClientOrders.Implementations;
using DeliveryCompany.Infrastructure.Persistence.ClientOrders.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Facilities;
using DeliveryCompany.Infrastructure.Persistence.Facilities.Implementation;
using DeliveryCompany.Infrastructure.Persistence.Facilities.Interfaces;
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
        services.AddScoped<ICourierRepository, CourierListRepository>();
        services.AddScoped<IAdministratorRepository, AdministratorListRepository>();
        // services.AddScoped<IClientOrderRepository, ClientOrderListRepository>();
        
        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped<IFacilities, FacilitiesList>();
        services.AddScoped<IAssignment, AssignmentList>();

        services.AddScoped<IClientOrderRepository, ClientOrderRepository>();
        services.AddScoped<IClientOrders, ClientOrdersList>();
        services.AddScoped<ICourierOrders, CourierOrdersList>();

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