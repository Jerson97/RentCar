using MediatR;
using RentCar.Application.Abstraction.Email;
using RentCar.Domain.Alquileres;
using RentCar.Domain.Alquileres.Events;
using RentCar.Domain.Users;

namespace RentCar.Application.Alquileres.ReservarAlquiler;

internal sealed class ReservarAlquilerDomainEventHandler : INotificationHandler<AlquilerReservadoDomainEvent>
{
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public ReservarAlquilerDomainEventHandler(IAlquilerRepository alquilerRepository, IUserRepository userRepository, IEmailService emailService)
    {
        _alquilerRepository = alquilerRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(AlquilerReservadoDomainEvent notification, CancellationToken cancellationToken)
    {
        var alquiler = await _alquilerRepository.GetByIdAsync(notification.AlquilerId, cancellationToken);

        if (alquiler is null)
        {
            return;
        }

        var user = await _userRepository.GetByIdAsync(
            alquiler.UserId!,
            cancellationToken
        );

        if (user is null)
        {
            return;
        }

        await _emailService.SendAsync(
            user.Email!,
            "Alquiler Reservado",
            "Tienes que confirmar esta reserva de lo contrario se va a perder"
        );
    }
}