using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMashup.Domain.Entities;


namespace WeatherMashup.Domain.Abstract
{
    interface IWeatherMashupService :IDisposable
    {
        IEnumerable<Location> getLocation(string cityName);

        IEnumerable<Weather> getWeather(int locationID);
    }
}
