using DeliveryCompany.Api.Common.Mapping;
using DeliveryCompany.Application.Interfaces.ClientOrders;
using DeliveryCompany.Application.ManageClientOrders;

namespace DeliveryCompany.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        
        services.AddScoped<IClientManage, ClientManage>();
        
        return services;
    }
}