using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Alquileres.Events;

public sealed record AlquilerRechazadoDomainEvent(AlquilerId Id) : IDomainEvent;