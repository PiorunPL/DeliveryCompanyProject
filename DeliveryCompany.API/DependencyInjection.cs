using DeliveryCompany.Api.Common.Mapping;
using DeliveryCompany.Application.ClientOrders;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrator;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client;

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