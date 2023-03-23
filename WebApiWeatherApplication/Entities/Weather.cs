namespace WebApiWeatherApplication.Entities;

public class Weather
{
    public Guid Id  {get;set;} = Guid.NewGuid();
    public string? City {get;set;}
    public double? Temperature {get;set;}
    public DateTime CreatedOn {get;set;} = DateTime.UtcNow;
}