using Microsoft.AspNetCore.Mvc;

namespace Bees.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{ 
    [HttpGet(Name = "GetWeatherForecast")]
    public void Get()
    {
        
    }
}
