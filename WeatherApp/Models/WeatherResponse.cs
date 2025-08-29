namespace WeatherApp.Models;

public class WeatherResponse
{
    public MainInfo Main { get; set; }
    public Weather[] Weather { get; set; }
    public WindInfo Wind { get; set; }
    public string Name { get; set; }
}

public class MainInfo
{
    public double Temp { get; set; }
    public double FeelsLike { get; set; }
    public int Humidity { get; set; }
}

public class Weather
{
    public string Description { get; set; }
}

public class WindInfo
{
    public double Speed { get; set; }
}