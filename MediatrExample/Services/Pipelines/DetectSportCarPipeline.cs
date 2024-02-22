using MediatR;
using MediatrExample.Models;
using Serilog;

namespace MediatrExample.Services.Pipelines;

public class DetectSportCarPipeline : IPipelineBehavior<CarIdentificationContext, CarIdentificationResult>
{
    private readonly ILogger _logger = Log.ForContext<DetectCrossoverPipeline>();
    private const CarModelType Type = CarModelType.SportCar;
    
    public async Task<CarIdentificationResult> Handle(CarIdentificationContext request,
        RequestHandlerDelegate<CarIdentificationResult> next, CancellationToken cancellationToken)
    {
        if (request.Car.Model != Type) return await next();
        
        _logger.Information("{Car} is {Type}!", request.Car.Name, Type);
        return new CarIdentificationResult { Match = true, Type = Type };
    }
}