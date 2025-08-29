using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Options;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Options;
using WeatherApp.Models;

namespace WeatherApp.Core.Services;

public sealed class WeatherService : IWeatherService
{
    private readonly HttpClient _http;
    private readonly OpenWeatherOptions _opts;
    private static readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };

    public WeatherService(HttpClient http, IOptions<OpenWeatherOptions> opts)
    {
        _http = http;
        _opts = opts.Value ?? throw new ArgumentNullException(nameof(opts));
        if (string.IsNullOrWhiteSpace(_opts.ApiKey))
            throw new InvalidOperationException("OpenWeather ApiKey is not configured.");
        if (_http.BaseAddress is null)
            _http.BaseAddress = new Uri(_opts.BaseUrl, UriKind.Absolute);
    }

    public async Task<WeatherResponse?> GetCurrentAsync(string city, string? units = null, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City is required.", nameof(city));
        units ??= _opts.DefaultUnits;

        var uri = $"/data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={_opts.ApiKey}&units={units}";
        using var resp = await _http.GetAsync(uri, ct);

        if (resp.StatusCode == HttpStatusCode.NotFound) return null;

        resp.EnsureSuccessStatusCode();
        await using var s = await resp.Content.ReadAsStreamAsync(ct);
        return await JsonSerializer.DeserializeAsync<WeatherResponse>(s, _json, ct);
    }
}