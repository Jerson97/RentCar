using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Alquileres.Events;

public sealed record AlquilerReservadoDomainEvent(AlquilerId AlquilerId) : IDomainEvent
{
    
}