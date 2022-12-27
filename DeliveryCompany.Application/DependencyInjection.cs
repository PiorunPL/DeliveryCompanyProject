using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        // services.AddSingleton<ILoggerFactory, LoggerFactory>();
        // services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
        return services;
    }
}