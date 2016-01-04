using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.Domain.Abstract
{
    interface IWeatherMashupRepository : IDisposable
    {   
        /// -----------------------------------
        ///           WEATHER 
        /// -----------------------------------
        IEnumerable<Weather> GetWeather(int locationID);      
        void InsertWeather(Weather weather);
        void UpdateWeather(Weather weather);
        void DeleteWeather(int WeatherID);
        /// -----------------------------------
        ///           LOCATION  
        /// -----------------------------------        
        IEnumerable<Location> getLocationsByCityName(string cityName);
        Location GetLocationByID(int LocationID);
        void InsertLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int LocationID);

        void Save();
        
    }
}
