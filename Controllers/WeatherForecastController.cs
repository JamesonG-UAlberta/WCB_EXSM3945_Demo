using Microsoft.AspNetCore.Mvc;

namespace API_Demo.Controllers
{
    [ApiController]
    // Our Class name is WeatherForecastController, therefore [controller] = WeatherForecast.
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Used for randomization.
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Standard logging stuff, don't need to edit these.
        private readonly ILogger<WeatherForecastController> _logger;
        // More logging stuff used with the constructor.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        // The part we care about - the endpoint. This one is for a GET request. You can have multiple types of request handlers in the same endpoint.
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // This is a super basic demo endpoint, so all it does is generate a random weather forecast using a random number for temperature, and a random summary.
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}