using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApiWeatherApplication.Entities;

namespace WebApiWeatherApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherParser _parser;
    private readonly IMemoryCache _cache;
    private readonly WeatherContext _context;

    public WeatherController(IWeatherParser parser, IMemoryCache cache, WeatherContext context) 
    {
        _parser = parser;
        _cache = cache;
        _context = context;
    }

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
                await _context.Set<Weather>().AddAsync(new Weather(){City = result.City, Temperature = result.Temperature});
                await _context.SaveChangesAsync();
            }
        }
        return result.Success ? Ok(result) : BadRequest(result);
    }
}