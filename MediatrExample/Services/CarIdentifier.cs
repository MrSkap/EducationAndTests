using MediatR;
using MediatrExample.Models;

namespace MediatrExample.Services;

public class CarIdentifier : ICarIdentifier
{
    private readonly IMediator _mediator;

    public CarIdentifier(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Dictionary<CarModelType, int>> IdentifyCars(IEnumerable<Car> cars)
    {
        var carsStatistic = new Dictionary<CarModelType, int>();
        foreach (var car in cars)
        {
            var detected = await _mediator.Send(new CarIdentificationContext { Car = car });

            if (!detected.Match) continue;

            if (carsStatistic.ContainsKey(car.Model))
            {
                carsStatistic[car.Model]++;
                continue;
            }

            carsStatistic.Add(car.Model, 1);
        }

        return carsStatistic;
    }
}