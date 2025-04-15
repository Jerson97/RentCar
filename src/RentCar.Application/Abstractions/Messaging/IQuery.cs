using MediatR;
using RentCar.Domain.Abstractions;

namespace RentCar.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}