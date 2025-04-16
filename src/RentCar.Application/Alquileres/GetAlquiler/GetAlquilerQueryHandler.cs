using Dapper;
using RentCar.Application.Abstraction.Data;
using RentCar.Application.Abstraction.Messaging;
using RentCar.Domain.Abstractions;

namespace RentCar.Application.Alquileres.GetAlquiler;

internal sealed class GetAlquilerQueryHandler : IQueryHandler<GetAlquilerQuery, AlquilerResponse>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public GetAlquilerQueryHandler(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Result<AlquilerResponse>> Handle(GetAlquilerQuery request, CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = """
            SELECT
                id AS  Id,
                vehiculo_id AS VehiculoId,
                user_id AS UserId,
                status AS Status,
                precio_por_periodo AS PrecioAlquiler,
                precio_por_periodo_tipo_moneda AS TipoMonedaAlquiler,
                precio_matenimiento AS PrecioMantenimiento,
                precio_mantenimiento_tipo_moneda AS TipoMonedaMantenimiento,
                precio_accesorios AS AccesoriosPrecio,
                precio_accesorios_tipo_moenda AS TipoMonedaAccesorio,
                precio_total AS PrecioTotal,
                precio_total_tipo_moenda AS PrecioTotalTipoMoneda,
                duracion_inicio AS DuracionInicio,
                duracion_Final AS DuracionFinal,
                fecha_creacion AS FechaCreacion               
            FROM alquileres WHERE id=@AlquilerId
        """;

        var alquiler = await connection.QueryFirstOrDefaultAsync<AlquilerResponse>(
            sql,
            new {
                request.AlquilerId
            }
        );

        return alquiler!;
    }
}
