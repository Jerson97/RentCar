using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Users;

public record UserId(Guid Value)
{
    public static UserId New() => new(Guid.NewGuid());
}