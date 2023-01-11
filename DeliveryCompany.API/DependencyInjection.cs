using DeliveryCompany.API.Common.MappingMapster;
using DeliveryCompany.Application.ClientOrders;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrators;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients;

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