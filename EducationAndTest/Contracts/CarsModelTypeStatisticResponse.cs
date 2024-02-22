using MediatrExample.Models;

namespace EducationAndTest.Contracts;

public record CarsModelTypeStatisticResponse(Dictionary<CarModelType, int> Statistic);