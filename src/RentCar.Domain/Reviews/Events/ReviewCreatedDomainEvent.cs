using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid AlquilerId) : IDomainEvent;