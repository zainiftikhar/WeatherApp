using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Options;
using WeatherApp.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Bind options (ApiKey comes from user-secrets)
builder.Services.Configure<OpenWeatherOptions>(builder.Configuration.GetSection("OpenWeather"));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Typed HttpClient for your service
builder.Services.AddHttpClient<IWeatherService, WeatherService>((sp, client) =>
{
    var opts = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<OpenWeatherOptions>>().Value;
    client.BaseAddress = new Uri(opts.BaseUrl);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();