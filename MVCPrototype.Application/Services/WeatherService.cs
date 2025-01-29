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

        public IEnumerable<WeatherForecast> GetWeather(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            int daysDifference = (end - start).Days + 1;

            return Enumerable.Range(0, daysDifference).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(start.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
