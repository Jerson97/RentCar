namespace RentCar.Domain.Vehiculos;

public record TipoMoneda
{
    public static readonly TipoMoneda None = new("");
    public static readonly TipoMoneda Usd = new("USD");
    public static readonly TipoMoneda Eur = new("EUR");

    private TipoMoneda(string codigo) => Codigo = codigo;
    public string? Codigo { get; set; }
    public static readonly IReadOnlyCollection<TipoMoneda> All = new []
    {
        Usd,
        Eur
    };

    public static TipoMoneda FromCodigo(string codigo)
    {
        return All.FirstOrDefault(x => x.Codigo == codigo) ??  throw new ApplicationException("El tipo de moneda es invalido");
    }
}