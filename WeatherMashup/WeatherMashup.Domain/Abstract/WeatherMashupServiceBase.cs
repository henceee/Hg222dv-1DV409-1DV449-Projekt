using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Entities;



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

        public abstract IEnumerable<Location> getLocation(string cityName);

        public abstract IEnumerable<Weather> getWeather(int locationID);
    }
}