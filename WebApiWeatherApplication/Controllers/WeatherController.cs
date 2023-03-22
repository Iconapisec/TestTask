using Microsoft.AspNetCore.Mvc;
using WeatherLib;

namespace WebApiWeatherApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherParser _parser;

    public WeatherController(WeatherParser parser) => _parser = parser;

    [HttpGet]
    [ProducesResponseType(typeof(Result),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWeather([FromQuery] string City)
    {
        if(string.IsNullOrEmpty(City))
        {
            return NoContent();
        }
        Result result = await _parser.GetWeather(City);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}