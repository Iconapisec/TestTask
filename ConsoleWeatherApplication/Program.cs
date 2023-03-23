using WeatherLib;

IWeatherParser parser = new OpenWeatherMapParser("f7612eba248c0e5548f0bd54c8c008b1");

var Minsk = parser.GetWeather("Minsk");
var London = parser.GetWeather("London");
var NewYork = parser.GetWeather("New York");

var results = await Task.WhenAll(new[]{Minsk,London,NewYork});

foreach(var result in results)
{
    Console.WriteLine(result);
}