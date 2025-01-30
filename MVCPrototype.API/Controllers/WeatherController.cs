using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCPrototype.Application.Services;
using MVCPrototype.Domain.Entities;

namespace MVCPrototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        private readonly IWeatherService _weatherService;


        public WeatherController(IConfiguration configuration, IWeatherService weatherService)
        {
            _configuration = configuration;
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("{startDate}/{endDate}")]
        public IActionResult Get(String startDate, String endDate)
        {
            var response = _weatherService.GetWeather(startDate, endDate);
            return StatusCode(200, response);
        }
    }
}
