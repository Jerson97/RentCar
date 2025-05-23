using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Alquileres.Events;

public sealed record AlquilerConfirmadoDomainEvent(AlquilerId AlquilerId) : IDomainEvent;