using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> lts = new List<WeatherForecast> ();
            lts.Add(new WeatherForecast() { id = 5, nombre = "Maria Ester Luna Rivera" });
            lts.Add(new WeatherForecast() { id = 6, nombre = "Jose Angel Azucena Mendez" });            
            return lts;
        }
    }
}
