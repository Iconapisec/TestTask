using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WeatherLib;

namespace WebApiWeatherApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherParser _parser;
    private readonly IMemoryCache _cache;

    public WeatherController(IWeatherParser parser, IMemoryCache cache) => (_parser,_cache) = (parser,cache);

    [HttpGet("{City}")]
    [ProducesResponseType(typeof(Result),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWeatherFromUrl(string City)
    {
        if(string.IsNullOrEmpty(City))
        {
            return NoContent();
        }

        if (!_cache.TryGetValue(City.ToUpper(), out Result result))
        {
            result = await _parser.GetWeather(City);
            if (result?.Success == true)
            {
                _cache.Set(City.ToUpper(), result, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }
        }
        return result.Success ? Ok(result) : BadRequest(result);
    }
}