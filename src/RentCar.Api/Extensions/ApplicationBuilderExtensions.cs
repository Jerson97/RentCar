using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCar.Api.Middleware;
using RentCar.Infrastructure;

namespace RentCar.Api.Extensions;

public static class ApplicationBuilderExtensions 
{
    public static async void ApplyMigration(this IApplicationBuilder app)
    {
        using(var scope = app.ApplicationServices.CreateScope())
        {
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error en migraciòn");
                
            }
        }
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}