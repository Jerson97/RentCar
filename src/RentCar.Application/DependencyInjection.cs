using Microsoft.Extensions.DependencyInjection;
using RentCar.Domain.Alquileres;

namespace RentCar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddTransient<PrecioService>();

        return services;
    }
}