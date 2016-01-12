using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.Domain.Abstract
{
    public interface IWeatherMashupRepository : IDisposable
    {   
        /// -----------------------------------
        ///           WEATHER 
        /// -----------------------------------
        #region weather
        IEnumerable<Weather> GetWeather(int locationID);      
        void InsertWeather(Weather weather);
        void UpdateWeather(Weather weather);
        void DeleteWeather(int WeatherID);
        #endregion
        /// -----------------------------------
        ///           LOCATION  
        /// -----------------------------------   
        #region location
        IEnumerable<Location> getLocationsByCityName(string cityName);
        Location GetLocationByID(int LocationID);
        void InsertLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int LocationID);
        IEnumerable<string> GetLocations(string term);
        #endregion
        //-------------SAVE-------------
        #region save
        void Save();
        #endregion

    }
}
