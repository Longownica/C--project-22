using System.Collections.Generic;

namespace Forum
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}