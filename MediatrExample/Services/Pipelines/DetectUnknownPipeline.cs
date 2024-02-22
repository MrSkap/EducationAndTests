using MediatR;
using MediatrExample.Models;
using Serilog;

namespace MediatrExample.Services.Pipelines;

public class DetectUnknownPipeline:IPipelineBehavior<CarIdentificationContext, CarIdentificationResult>
{
    private readonly ILogger _logger = Log.ForContext<DetectCrossoverPipeline>();
    private const CarModelType Type = CarModelType.Unknown;
    
    public Task<CarIdentificationResult> Handle(CarIdentificationContext request,
        RequestHandlerDelegate<CarIdentificationResult> next, CancellationToken cancellationToken)
    {
        _logger.Information("{Car} is {Type}!", request.Car.Name, Type);
        return Task.FromResult(new CarIdentificationResult { Match = true, Type = Type });
    }
}