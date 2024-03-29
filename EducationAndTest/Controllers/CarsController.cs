using EducationAndTest.Contracts;
using MediatrExample.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace EducationAndTest.Controllers;

[ApiController]
[Route("cars")]
public class CarsController : ControllerBase
{
    private static readonly ILogger Logger = Log.ForContext<CarsController>();
    private readonly ICarIdentifier _carIdentifier;

    public CarsController(ICarIdentifier carIdentifier)
    {
        _carIdentifier = carIdentifier;
    }

    [HttpGet("statistics")]
    public async Task<CarsModelTypeStatisticResponse> GetCarsModelTypeStatistic(CarsModelTypeStatisticRequest request)
    {
        Logger.Information("Analyze statistic of given cars...");
        return new CarsModelTypeStatisticResponse(await _carIdentifier.IdentifyCars(request.Cars));
    }
}