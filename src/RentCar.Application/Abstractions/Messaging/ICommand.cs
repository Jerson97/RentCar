using MediatR;
using RentCar.Domain.Abstractions;

namespace RentCar.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{

}

public interface IBaseCommand
{
    
}