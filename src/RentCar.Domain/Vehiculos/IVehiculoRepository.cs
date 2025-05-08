namespace RentCar.Domain.Vehiculos;

public interface IVehiculoRepository
{
    Task<Vehiculo?> GetByIdAsync(VehiculoId id, CancellationToken cancellationToken = default);
}