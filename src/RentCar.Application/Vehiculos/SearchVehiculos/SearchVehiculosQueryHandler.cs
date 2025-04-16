using Dapper;
using RentCar.Application.Abstraction.Data;
using RentCar.Application.Abstraction.Messaging;
using RentCar.Domain.Abstractions;
using RentCar.Domain.Alquileres;

namespace RentCar.Application.Vehiculos.SearchVehiculos;

internal sealed class SearchVehiculosQueryHandler : IQueryHandler<SearchVehiculosQuery, IReadOnlyList<VehiculoResponse>>
{
    private readonly int[] ActiveAlquilerStatuses = 
    {
        (int)AlquilerStatus.Reservado,
        (int)AlquilerStatus.Confirmado,
        (int)AlquilerStatus.Completado,
    };
    private readonly ISqlConnectionFactory _connectionFactory;

    public SearchVehiculosQueryHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(SearchVehiculosQuery request, CancellationToken cancellationToken)
    {
        if (request.fechaInicio > request.fechaFin)
        {
            return new List<VehiculoResponse>();
        }

        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                a.id as Id,
                a.modelo as Modelo,
                a.vin as Vin,
                a.precio_monto as Precio,
                a.precio_tipo_moneda as TipoMoneda,
                a.direccion_pais as Pais
                a.direccion_departamento as Departamento,
                a.direccion_provincia as Provincia,
                a.direccion_ciudad as Ciudad,
                a.direccion_calle as calle
            FROM vehiculos AS a
            WHERE NOT EXISTS
            (
                SELECT 1 
                FROM alquiler AS b
                WHERE
                    b.vehiculo_id = a.id
                    b.duracion_inicio <= @EndDate AND
                    b.duracion_final >= @StarDate AND
                    b.status = ANY(@ActiveAlquilerStatuses)
            )
        """;

        var vehiculos = await connection.QueryAsync<VehiculoResponse, DireccionResponse, VehiculoResponse>
        (
            sql,
            (vehiculo, direccion) => {
                vehiculo.Direccion = direccion;
                return vehiculo;
            },
            new 
            {
                StartDate = request.fechaInicio,
                EndDate = request.fechaFin,
                ActiveAlquilerStatuses
            },
            splitOn: "Pais"
        );

        return vehiculos.ToList();
    }
}
