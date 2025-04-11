namespace RentCar.Domain.Vehiculos;

public interface IVehiculoRepository
{
    Task<Vehiculo?> GetById(Guid id, CancellationToken cancellationToken = default);
}