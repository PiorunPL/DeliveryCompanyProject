using DeliveryCompany.Api.Common.Mapping;
using DeliveryCompany.Application.Interfaces.ManageClientOrders;
using DeliveryCompany.Application.ManageClientOrders;

namespace DeliveryCompany.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        
        services.AddScoped<IManageClientOrders, ManageClientOrders>();
        
        return services;
    }
}