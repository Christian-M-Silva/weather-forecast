using System.Globalization;

namespace MVCPrototype.Domain.Entities
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public string DayOfWeek => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
            Date.ToString("dddd", new CultureInfo("pt-BR"))
        );
        public string FormattedDate => Date.ToString("dd/MM/yyyy", new CultureInfo("pt-BR"));
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}
