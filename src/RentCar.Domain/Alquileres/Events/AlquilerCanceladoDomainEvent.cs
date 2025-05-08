using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Alquileres.Events;

public sealed record AlquilerCanceladoDomainEvent(AlquilerId AlquilerId) : IDomainEvent;