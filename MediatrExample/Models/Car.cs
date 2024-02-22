namespace MediatrExample.Models;

public class Car
{
    public CarModelType Model { get; set; } = CarModelType.Unknown;
    public string Name { get; set; } = string.Empty;
    public int Weight { get; set; }
}