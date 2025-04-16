namespace RentCar.Application.Alquileres.GetAlquiler;

public sealed class AlquilerResponse
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid VehiculoId { get; init; }
    public int Status { get; init; }
    public decimal PrecioAlquiler { get; init; }
    public string? TipoMonedaAlquiler {get; init; }
    public decimal PrecioMantenimiento { get; init; }
    public decimal TipoMonedaMantenimiento { get; init; }
    public decimal AccesoriosPrecio { get; init; }
    public string? TipoMonedaAccesorio { get; init; }
    public decimal PrecioTotal { get; init; }
    public string? PrecioTotalTipoMoneda { get; init; }
    public DateOnly DuracionInicio { get; init; }
    public DateOnly DuracionFinal { get; init; }
    public DateTime FechaCreaciom { get; init; }
}