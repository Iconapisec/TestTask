using WeatherLib;

namespace WebApiWeatherApplication;

public static class ServicesExtension
{
    public static void AddWeatherParser(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IWeatherParser>(new OpenWeatherMapParser(configuration.GetValue<string>("APIKEY")));
    }
}