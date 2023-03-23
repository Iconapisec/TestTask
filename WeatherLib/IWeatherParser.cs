namespace WeatherLib;

public interface IWeatherParser
{
    Task<Result> GetWeather(string city);
}