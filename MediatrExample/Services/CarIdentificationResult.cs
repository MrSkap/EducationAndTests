using MediatrExample.Models;

namespace MediatrExample.Services;

public class CarIdentificationResult
{
    public CarModelType Type { get; set; }
    public bool Match { get; set; }
}