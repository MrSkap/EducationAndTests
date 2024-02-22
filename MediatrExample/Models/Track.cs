namespace MediatrExample.Models;

public class Track : Car
{
    public CarModelType Model { get; } = CarModelType.Track;
    public string Name { get; set; }
    public int Weight { get; set; }
    public int MaxWeight { get; set; }
    public int Reels { get; set; }
}