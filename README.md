WeatherApp

A simple console-based weather application built in C# that fetches current weather information for a given city using the OpenWeather API.

Features

Get current weather for any city.

Displays:

Weather description (e.g., cloudy, sunny, etc.)

Temperature and feels-like temperature (°C)

Humidity (%)

Wind speed (m/s)

Simple and easy-to-use console interface.

Requirements

.NET 7.0 SDK
 or later.

OpenWeather API key (for accessing weather data).

Setup

Clone the repository

git clone <repository_url>
cd WeatherApp


Set up your API key
Obtain a free API key from OpenWeather
.
Set it as an environment variable named OPENWEATHER_API_KEY.

Windows (PowerShell):

$env:OPENWEATHER_API_KEY="your_api_key_here"


Linux/macOS (Bash):

export OPENWEATHER_API_KEY="your_api_key_here"


Build the project

dotnet build


Run the application

dotnet run

Usage

Run the app.

Enter the city name when prompted.

View the weather details displayed in the console.

Example Output:

Enter city name:
London

Weather in London:
- Light rain
- Temperature: 15°C (Feels like 14°C)
- Humidity: 72%
- Wind Speed: 3.5 m/s

Project Structure
WeatherApp/
│
├─ Program.cs              # Main console app
├─ Services/
│  └─ WeatherService.cs    # Handles API requests
├─ Models/
│  └─ WeatherResponse.cs   # Data models for weather response
└─ README.md

Dependencies

System.Net.Http – for making HTTP requests

System.Text.Json – for JSON serialization/deserialization

Notes

Make sure your API key is valid and has not exceeded the free usage limit.

Handles basic error scenarios like invalid city names or failed API requests.
