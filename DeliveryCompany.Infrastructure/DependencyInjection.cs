using System.Text;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Infrastructure.Authentication;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders;
using DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Common.Facilities;
using DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;
using DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.ClientOrders;
using DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.Facilities;
using DeliveryCompany.Infrastructure.Persistence.Implementations.List;
using DeliveryCompany.Infrastructure.Persistence.Implementations.List.ClientOrders;
using DeliveryCompany.Infrastructure.Persistence.Implementations.List.Facilities;
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
        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped<IClientOrderRepository, ClientOrderRepository>();

        // services.ListRepositories();
        services.AddDataBaseRepositories();

        return services;
    }

    public static IServiceCollection AddDataBaseRepositories(this IServiceCollection services)
    {
        services.AddDbContext<DeliveryDbContext>();
        
        services.AddScoped<IClientRepository, ClientMySqlRepository>();
        services.AddScoped<ICourierRepository, CourierMySqlRepository>();
        services.AddScoped<IAdministratorRepository, AdministratorMySqlRepository>();
        
        services.AddScoped<ISizeRepository, SizeMySqlRepository>();
        
        services.AddScoped<IFacilities, FacilitiesMySql>();
        services.AddScoped<IAssignment, AssignmentMySql>();
        
        services.AddScoped<IClientOrders, ClientOrderMySql>(); 
        services.AddScoped<ICourierOrders, CourierOrderMySql>();

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