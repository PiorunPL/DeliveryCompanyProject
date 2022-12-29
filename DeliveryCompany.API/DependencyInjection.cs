using DeliveryCompany.Api.Common.Mapping;
using DeliveryCompany.Application.Interfaces.ClientOrders.Client;
using DeliveryCompany.Application.ClientOrders;
using DeliveryCompany.Application.Interfaces.ClientOrders.Administrator;

namespace DeliveryCompany.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        
        services.AddScoped<IClientManage, ClientManage>();
        services.AddScoped<IAdministratorManage, AdministratorManage>();
        
        return services;
    }
}