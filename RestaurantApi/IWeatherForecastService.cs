using System.Collections.Generic;

namespace RestaurantApi
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTempeature);
    }
}