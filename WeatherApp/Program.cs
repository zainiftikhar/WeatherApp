using WeatherApp.Services;

class Program
{
    static async Task Main()
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Error: Missing API key.");
            return;
        }

        var weatherService = new WeatherService(apiKey);

        Console.WriteLine("Enter city name:");
        var city = Console.ReadLine();

        var weather = await weatherService.GetWeatherAsync(city ?? "");
        if (weather == null)
        {
            Console.WriteLine("City not found or error fetching weather.");
            return;
        }

        Console.WriteLine($"\nWeather in {weather.Name}:");
        Console.WriteLine($"- {weather.Weather[0].Description}");
        Console.WriteLine($"- Temperature: {weather.Main.Temp}°C (Feels like {weather.Main.FeelsLike}°C)");
        Console.WriteLine($"- Humidity: {weather.Main.Humidity}%");
        Console.WriteLine($"- Wind Speed: {weather.Wind.Speed} m/s");
    }
}