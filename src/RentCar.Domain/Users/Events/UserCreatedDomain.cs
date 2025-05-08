using RentCar.Domain.Users;

namespace RentCar.Domain.Abstractions;

public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;