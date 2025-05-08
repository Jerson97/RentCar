using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(ReviewId ReviewId) : IDomainEvent;