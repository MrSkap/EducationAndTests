namespace MediatrExample.Models;

public class SportCar : Car
{
    public CarModelType Model { get; } = CarModelType.SportCar;
    public string Name { get; set; }
    public int Weight { get; set; }
    public double EnginePower { get; set; }
    public int MaxSpeed { get; set; }
    public double TimeFor100Km { get; set; }
}