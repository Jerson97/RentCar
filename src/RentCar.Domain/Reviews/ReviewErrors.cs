using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Reviews;

public static class ReviewErrors
{
    public static readonly Error NotEligible = new ("Review.NotEligible", "Este review y calificacion para el auto no es eligible por que aun no se completa");
}