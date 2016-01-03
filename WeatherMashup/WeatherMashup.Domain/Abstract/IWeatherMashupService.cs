using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMashup.Domain.Datamodels.WeatherMashup;
using WeatherMashup.Domain.DataModels;

namespace WeatherMashup.Domain.Abstract
{
    interface IWeatherMashupService :IDisposable
    {
        IEnumerable<LocationModel> getLocation(string cityName);

        IEnumerable<WeatherModel> getWeather(LocationModel location);
    }
}
