namespace MediatrExample.Models;

public class Crossover : Car
{
    public CarModelType Model { get; set; } = CarModelType.Crossover;
    public string Name { get; set; }
    public int Weight { get; set; }
}