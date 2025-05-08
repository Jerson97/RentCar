using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Alquileres.Events;

public sealed record AlquilerCompletadoDomainEvent(AlquilerId AlquilerId) : IDomainEvent;