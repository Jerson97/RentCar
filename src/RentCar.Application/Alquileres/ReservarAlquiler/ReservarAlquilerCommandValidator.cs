using FluentValidation;

namespace RentCar.Application.Alquileres.ReservarAlquiler;

public class ReservarAlquilerCommandValidator : AbstractValidator<ReservarAlquilerCommand>
{
    public ReservarAlquilerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.VehiculoId).NotEmpty();
        RuleFor(c => c.FechaInicio).LessThan(c => c.FechaFin);
    }
}