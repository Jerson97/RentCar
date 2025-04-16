using RentCar.Application.Abstraction.Messaging;

namespace RentCar.Application.Alquileres.ReservarAlquiler;

public record ReservarAlquilerCommand(Guid VehiculoId, Guid UserId, DateOnly FechaInicio, DateOnly FechaFin) : ICommand<Guid>;