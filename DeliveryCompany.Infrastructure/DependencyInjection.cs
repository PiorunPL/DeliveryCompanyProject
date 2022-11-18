using DeliveryCompany.Application.Common.Interfaces.Persistance;
using DeliveryCompany.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryCompany.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}