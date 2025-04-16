namespace RentCar.Application.Abstraction.Clock;

public interface IDateTimeProvider
{
    DateTime currentTime { get; }
}