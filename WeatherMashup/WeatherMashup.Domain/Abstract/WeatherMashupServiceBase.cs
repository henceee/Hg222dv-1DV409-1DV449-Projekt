using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.Abstract
{
    public abstract class WeatherMashupServiceBase : IWeatherMashupService
    {
        protected virtual void Dispose(bool disposing)
        {
         
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract IEnumerable<Datamodels.WeatherMashup.LocationModel> getLocation(string cityName);

        public abstract IEnumerable<DataModels.WeatherModel> getWeather(Datamodels.WeatherMashup.LocationModel location);
    }
}