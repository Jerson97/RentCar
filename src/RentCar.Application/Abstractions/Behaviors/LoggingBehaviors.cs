using MediatR;
using Microsoft.Extensions.Logging;
using RentCar.Application.Abstraction.Messaging;

namespace RentCar.Application.Abstraction.Behaviors;

public class LoggingBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
{
   private readonly ILogger<TRequest> _logger;

    public LoggingBehaviors(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;
        
        try
        {
            _logger.LogInformation($"Ejecutando el command request: {name}");
            var result = await next();
            _logger.LogInformation($"El comando {name} se ejecuto exitosamente");

            return result;
        }
        catch (Exception exception)
        {
            
            _logger.LogError(exception, $"El comando {name} tuvo errores");
            throw;
        }
    }
}
