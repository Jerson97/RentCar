using RentCar.Application.Abstraction.Messaging;

namespace RentCar.Application.Vehiculos.SearchVehiculos;

public sealed record SearchVehiculosQuery(DateOnly fechaInicio, DateOnly fechaFin) : IQuery<IReadOnlyList<VehiculoResponse>>;