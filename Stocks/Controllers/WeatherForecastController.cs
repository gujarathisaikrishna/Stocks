using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Stocks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpGet]
        [Route("{take}/example")]
        public IEnumerable<WeatherForecast> Get([FromQuery]int max, [FromRoute]int take)
        {
            var result = _weatherForecastService.Get();
            return result;
        }
        //[HttpGet(Name = "CurrentDay")]
        [HttpGet]
        [Route("currentDay")]
        public WeatherForecast GetCurrentDay()
        {
            var result = _weatherForecastService.Get().First();
            return result;
        }

        [HttpPost]
        public string Hello([FromBody] string name)
        {
            return $"Hello {name}";
        }
    }
}
