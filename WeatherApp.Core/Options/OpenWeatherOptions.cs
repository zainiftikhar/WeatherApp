namespace WeatherApp.Core.Options;

public class OpenWeatherOptions
{
    public string? ApiKey { get; set; }
    public string BaseUrl { get; set; } = "https://api.openweathermap.org/";
    public string DefaultUnits { get; set; } = "metric"; // "imperial" if you prefer °F
}