using DeliveryCompany.API.Common.MappingMapster;

//Implementations
using ClientOrders = DeliveryCompany.Application.ClientOrders;
using CourierOrders = DeliveryCompany.Application.CourierOrders;
using Couriers = DeliveryCompany.Application.Couriers;
using Facilities = DeliveryCompany.Application.Facilities;
using Sizes = DeliveryCompany.Application.Sizes;

//Interfaces
using IClientOrders = DeliveryCompany.Application.Interfaces.OutServices.ClientOrders;
using ICourierOrders = DeliveryCompany.Application.Interfaces.OutServices.CourierOrders;
using ICouriers = DeliveryCompany.Application.Interfaces.OutServices.Couriers;
using IFacilities = DeliveryCompany.Application.Interfaces.OutServices.Facilities;
using ISizes = DeliveryCompany.Application.Interfaces.OutServices.Sizes;

namespace DeliveryCompany.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();

        services.AddClientOrdersManagement();
        services.AddCourierOrdersManagement();
        services.AddCouriersManagement();
        services.AddFacilitiesManagement();
        services.AddSizesManagement();

        return services;
    }

    private static IServiceCollection AddClientOrdersManagement(this IServiceCollection services)
    {
        services.AddScoped<IClientOrders.Clients.IClientManage, ClientOrders.ClientManage>();
        services.AddScoped<IClientOrders.Administrators.IAdministratorManage, ClientOrders.AdministratorManage>();
        return services;
    }

    private static IServiceCollection AddCourierOrdersManagement(this IServiceCollection services)
    {
        services.AddScoped<ICourierOrders.Couriers.ICourierManage, CourierOrders.CourierManage>();
        services.AddScoped<ICourierOrders.Administrators.IAdministratorManage, CourierOrders.AdministratorManage>();
        return services;
    }

    private static IServiceCollection AddCouriersManagement(this IServiceCollection services)
    {
        services.AddScoped<ICouriers.Administrators.IAdministratorManage, Couriers.AdministratorManage>();
        return services;
    }

    private static IServiceCollection AddFacilitiesManagement(this IServiceCollection services)
    {
        services.AddScoped<IFacilities.Administrators.IAdministratorManage, Facilities.AdministratorManage>();
        return services;
    }

    private static IServiceCollection AddSizesManagement(this IServiceCollection services)
    {
        services.AddScoped<ISizes.Administrators.IAdministratorManage, Sizes.AdministratorManage>();
        services.AddScoped<ISizes.Clients.IClientManage, Sizes.ClientManage>();
        return services;
    }
}