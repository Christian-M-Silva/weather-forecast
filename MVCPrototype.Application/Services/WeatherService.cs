using MVCPrototype.Domain.Entities;

namespace MVCPrototype.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Raining", "Smog", "Sunny"
        };

        public WeatherService() { }

        public IEnumerable<WeatherForecast> GetWeather()
        {
            return Enumerable.Range(0, 7).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
        }
    }
}
