using MediatR;

namespace MediatrExample.Services;

public class DetectCarHandler : IRequestHandler<CarIdentificationContext, CarIdentificationResult>
{
    public Task<CarIdentificationResult> Handle(CarIdentificationContext request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CarIdentificationResult());
    }
}