using RentCar.Domain.Vehiculos;

namespace RentCar.Infrastructure.Repositories;

internal sealed class VehiculoRepository : Repository<Vehiculo, VehiculoId>, IVehiculoRepository
{
    public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
