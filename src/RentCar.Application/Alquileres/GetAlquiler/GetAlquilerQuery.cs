using RentCar.Application.Abstraction.Messaging;

namespace RentCar.Application.Alquileres.GetAlquiler;

public sealed record GetAlquilerQuery(Guid AlquilerId) : IQuery<AlquilerResponse>;