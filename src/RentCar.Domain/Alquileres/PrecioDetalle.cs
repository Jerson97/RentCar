using RentCar.Domain.Vehiculos;

namespace RentCar.Domain.Alquileres;

public record PrecioDetalle(Moneda PrecioPorPeriodo, Moneda Mantenimiento, Moneda Accesorio, Moneda PrecioTotal);