using RentCar.Application.Abstraction.Clock;

namespace RentCar.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}