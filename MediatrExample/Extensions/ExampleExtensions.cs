using System.Reflection;
using MediatrExample.Services;
using MediatrExample.Services.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrExample.Extensions;

public static class ExampleExtensions
{
    public static void AddMediatrExample(this IServiceCollection collection)
    {
        collection.AddTransient<DetectCrossoverPipeline>();
        collection.AddTransient<DetectCoupePipeline>();
        collection.AddTransient<DetectSportCarPipeline>();
        collection.AddTransient<DetectUnknownPipeline>();
        collection.AddTransient<DetectSedanPipeline>();
        collection.AddTransient<ICarIdentifier, CarIdentifier>();
        collection.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}