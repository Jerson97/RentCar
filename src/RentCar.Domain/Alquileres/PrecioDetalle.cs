using RentCar.Domain.Shared;

namespace RentCar.Domain.Alquileres;

public record PrecioDetalle(Moneda PrecioPorPeriodo, Moneda Mantenimiento, Moneda Accesorio, Moneda PrecioTotal);