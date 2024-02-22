using MediatrExample.Models;

namespace MediatrExample.Services;

public interface ICarIdentifier
{
    Task<Dictionary<CarModelType, int>> IdentifyCars(IEnumerable<Car> cars);
}