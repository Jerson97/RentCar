using RentCar.Domain.Vehiculos;

namespace RentCar.Domain.Alquileres;

public interface IAlquilerRepository
{
    Task<Alquiler?> GetByIdAsync(AlquilerId id, CancellationToken cancellationToken = default);
    
    Task<bool> IsOverlappingAsync(Vehiculo vehiculo, DateRange dateRange, CancellationToken cancellationToken = default);

    void Add(Alquiler alquiler);
}