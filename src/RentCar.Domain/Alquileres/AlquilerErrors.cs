using RentCar.Domain.Abstractions;

namespace RentCar.Domain.Alquileres;

public static class AlquilerErrors
{
    public static Error NotFound = new (
        "Alquiler.Found",
        "El alquiler con el Id especifico no fue encontrado"
    );

    public static Error OverLap = new Error(
        "Alquiler.Overlap",
        "El Alquiler esta siendo tomado por 2 o mas clientes al mismo tiempo en la misma fecha"
    );

    public static Error NotReserved = new Error(
        "Alquiler.NotReserved",
        "El alquiler no esta reservado"
    );

    public static Error NotConfirmed = new Error(
        "Alquiler.NotConfirmed",
        "El alquiler no esta confirmado"
    );

    public static Error AlreadyStarted = new Error(
        "Alquiler.AlreadyStarted",
        "El alquiler ya ha comenzado"
    );
}