using WeatherApp.Models;

namespace WeatherApp.Core.Interfaces;

public interface IWeatherService
{
    Task<WeatherResponse?> GetCurrentAsync(string city, string? units = null, CancellationToken ct = default);
}