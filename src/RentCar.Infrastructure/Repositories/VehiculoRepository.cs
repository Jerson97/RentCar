using RentCar.Domain.Vehiculos;

namespace RentCar.Infrastructure.Repositories;

internal sealed class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
{
    public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
