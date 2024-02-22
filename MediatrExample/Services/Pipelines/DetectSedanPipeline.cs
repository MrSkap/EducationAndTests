using MediatR;
using MediatrExample.Models;
using Serilog;

namespace MediatrExample.Services.Pipelines;

public class DetectSedanPipeline : IPipelineBehavior<CarIdentificationContext, CarIdentificationResult>
{
    private readonly ILogger _logger = Log.ForContext<DetectCrossoverPipeline>();
    private const CarModelType Type = CarModelType.Sedan;
    
    public Task<CarIdentificationResult> Handle(CarIdentificationContext request,
        RequestHandlerDelegate<CarIdentificationResult> next, CancellationToken cancellationToken)
    {
        if (request.Car.Model != Type)
        {
            return Task.FromResult(new CarIdentificationResult { Match = false });
        }
        
        _logger.Information("{Car} is {Type}!", request.Car.Name, Type);
        return Task.FromResult(new CarIdentificationResult { Match = true, Type = Type });
    }
}