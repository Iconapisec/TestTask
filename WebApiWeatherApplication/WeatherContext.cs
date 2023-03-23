using WebApiWeatherApplication.Entities;

namespace WebApiWeatherApplication;

public class WeatherContext : DbContext
{

    public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Weather> Weathers {get;set;}
}