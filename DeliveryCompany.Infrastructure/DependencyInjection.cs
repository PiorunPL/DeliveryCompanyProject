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

        services.AddRepositories();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IFacilityRepository, FacilityRepository>();
        services.AddSingleton<IClientOrderRepository, ClientOrderRepository>();

        services.ListRepositories();
        //DataBaseRepositories();

        return services;
    }
    public static IServiceCollection ListRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IClientRepository, ClientListRepository>();
        services.AddSingleton<ICourierRepository, CourierListRepository>();
        services.AddSingleton<IAdministratorRepository, AdministratorListRepository>();
        
        services.AddSingleton<ISizeRepository, SizeListRepository>();
        
        services.AddSingleton<IFacilities, FacilitiesList>();
        services.AddSingleton<IAssignment, AssignmentList>();
        
        services.AddSingleton<IClientOrders, ClientOrdersList>();
        services.AddSingleton<ICourierOrders, CourierOrdersList>();

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