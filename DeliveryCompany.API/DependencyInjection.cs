using DeliveryCompany.Api.Common.Mapping;

namespace DeliveryCompany.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        
        return services;
    }
}