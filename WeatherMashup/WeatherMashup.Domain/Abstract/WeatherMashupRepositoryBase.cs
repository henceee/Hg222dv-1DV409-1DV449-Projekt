using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.Domain.Abstract
{
    public abstract class WeatherMashupRepositoryBase : IWeatherMashupRepository
    {
        #region Dispose
        protected virtual void Dispose(bool dispose)
        {
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        ///           WEATHER 
        #region Weather
        protected abstract IQueryable<Weather> QueryWeather();

        public IEnumerable<Weather> GetWeather(int locationID)
        {
            return QueryWeather().Select(w => w).Where(w => w.LocationID == locationID).ToList();
        }

        public abstract void InsertWeather(Weather weather);
        public abstract void UpdateWeather(Weather weather);
        public abstract void DeleteWeather(int WeatherID);
        #endregion        
        ///           LOCATION      
        #region Location
        protected abstract IQueryable<Location> QueryLocation();

        public IEnumerable<Location> getLocationsByCityName(string cityName)
        {
            return QueryLocation().Select(l => l).Where(l => l.CityName == cityName).ToList();
        }

        public Location GetLocationByID(int LocationID)
        {
            return QueryLocation().SingleOrDefault(l => l.LocationID == LocationID);
        }

        public abstract void InsertLocation(Location location);
        public abstract void UpdateLocation(Location location);
        public abstract void DeleteLocation(int LocationID);

        #endregion

        #region Save
        public abstract void Save();
        #endregion
    }
}