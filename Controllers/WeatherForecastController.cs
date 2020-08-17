using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostmanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private static Random _rng = new Random();
        private static List<WeatherForecast> _weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = _rng.Next(-20, 55),
            Summary = Summaries[_rng.Next(Summaries.Length)]
        }).ToList();


        [HttpGet]
        public IEnumerable<WeatherForecast> Get() => _weatherForecasts;

        [HttpPost]
        public void Post(WeatherForecast weatherForecast) => _weatherForecasts.Add(weatherForecast);
    }
}
