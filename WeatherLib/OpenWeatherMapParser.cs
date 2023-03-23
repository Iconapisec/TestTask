using Newtonsoft.Json.Linq;

namespace WeatherLib;

public class OpenWeatherMapParser : IWeatherParser
{
    private readonly string _apiKey;
    private readonly HttpClient client = new();

    public OpenWeatherMapParser(string apiKey) => _apiKey = apiKey;

    public async Task<Result> GetWeather(string city)
    {
        try
        {
            var request = await client.GetAsync(new Uri($"https://api.openweathermap.org/data/2.5/weather?q={city}&lang=ru&units=metric&appid={_apiKey}"));
            dynamic response = JObject.Parse(await request.Content.ReadAsStringAsync());
            return new Result(city,Math.Round(Convert.ToDouble(response?.main.temp)),true);
        }
        catch
        {
            return new Result(city,null,false);
        }
    }
}

public record Result(string? City, double? Temperature, bool Success);