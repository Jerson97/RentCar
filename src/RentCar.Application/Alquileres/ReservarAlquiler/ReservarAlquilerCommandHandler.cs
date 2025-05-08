using RentCar.Application.Abstraction.Clock;
using RentCar.Application.Abstraction.Messaging;
using RentCar.Application.Exceptions;
using RentCar.Domain.Abstractions;
using RentCar.Domain.Alquileres;
using RentCar.Domain.Users;
using RentCar.Domain.Vehiculos;

namespace RentCar.Application.Alquileres.ReservarAlquiler;

internal sealed class ReservarAlquilerCommandHandler : ICommandHandler<ReservarAlquilerCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly PrecioService _precioService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ReservarAlquilerCommandHandler(IUserRepository userRepository, IVehiculoRepository vehiculoRepository, IAlquilerRepository alquilerRepository, PrecioService precioService, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _precioService = precioService;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(ReservarAlquilerCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var vehiculoId = new VehiculoId(request.VehiculoId);
        var vehiculo = await _vehiculoRepository.GetByIdAsync(vehiculoId, cancellationToken);
        if (vehiculo is null)
        {
            return Result.Failure<Guid>(VehiculoErrors.NotFound);
        }

        var duracion = DateRange.Create(request.FechaInicio, request.FechaFin);

            if (await _alquilerRepository.IsOverlappingAsync(vehiculo, duracion, cancellationToken))
            {
                return Result.Failure<Guid>(AlquilerErrors.OverLap);
            }

            try
            {
                var alquiler = Alquiler.Reservar(
                vehiculo,
                user.Id!,
                duracion,
                _dateTimeProvider.currentTime,
                _precioService
            );

            _alquilerRepository.Add(alquiler);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return alquiler.Id!.Value;

            }
            catch (ConcurrencyException)
            {
                
                return Result.Failure<Guid>(AlquilerErrors.OverLap);
            }

            

            
    }
}
