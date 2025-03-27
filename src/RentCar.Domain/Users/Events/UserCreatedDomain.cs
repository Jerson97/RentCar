namespace RentCar.Domain.Abstractions;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;