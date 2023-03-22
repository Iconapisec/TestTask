using WeatherLib;

namespace WebApiWeatherApplication;

public static class ServicesExtension
{
    public static void AddWeatherParser(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new WeatherParser(configuration.GetValue<string>("APIKEY")));
    }
}