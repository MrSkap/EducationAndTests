using MediatrExample.Services;
using MediatrExample.Services.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrExample.Extensions;

public static class ExampleExtensions
{
    public static void AddMediatrExample(this IServiceCollection collection)
    {
        collection.AddTransient<ICarIdentifier, CarIdentifier>();
        collection.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(DetectCarHandler).Assembly);
            x.AddBehavior<DetectCrossoverPipeline>();
            x.AddBehavior<DetectCoupePipeline>();
            x.AddBehavior<DetectSportCarPipeline>();
            x.AddBehavior<DetectUnknownPipeline>();
            x.AddBehavior<DetectSedanPipeline>();
        });
    }
}