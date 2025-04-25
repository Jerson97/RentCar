using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Alquileres;
using RentCar.Domain.Vehiculos;
using RentCar.Infrastructure.Repositories;

namespace RentCar.Infrastructure.Repositories;

internal sealed class AlquilerRepository : Repository<Alquiler>, IAlquilerRepository
{
    private static readonly AlquilerStatus[] ActiveAlquilerStatuses = {
        AlquilerStatus.Reservado,
        AlquilerStatus.Confirmado,
        AlquilerStatus.Completado
    };
    public AlquilerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<bool> IsOverlappingAsync(Vehiculo vehiculo, DateRange duracion, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Alquiler>().AnyAsync(
            alquiler => 
                alquiler.VehiculoId == vehiculo.Id &&
                alquiler.Duracion!.Inicio <= duracion.Fin &&
                alquiler.Duracion.Fin >= duracion.Inicio &&
                ActiveAlquilerStatuses.Contains(alquiler.Status),
                cancellationToken
        );
    }
}
