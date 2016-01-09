using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.ViewModels
{
    public class ForecastViewModel
    {
        public IEnumerable<Domain.Entities.Weather> Forecast { get; set; }

        public string CityName { get { return Forecast.First().Location.CityName; } }

        public Weather TodaysWeather { get { return getDaysWeather(DateTime.Now); } }
        public Weather TomorrowsWeather { get { return getDaysWeather(DateTime.Now.AddDays(1)); } }
        public Weather WeatherThreeDaysFromNow { get { return getDaysWeather(DateTime.Now.AddDays(2)); } }
        public Weather WeatherFourDaysFromNow { get { return getDaysWeather(DateTime.Now.AddDays(3)); } }
        public Weather WeatherFiveDaysFromNow { get { return getDaysWeather(DateTime.Now.AddDays(4)); } }      

        private Weather getDaysWeather(DateTime day)
        {            
                    //if there is a forecast for period 2 of this day, use it...
            return Forecast.FirstOrDefault(w => w.Period == 2 && w.ForecastDate == day)
                   //otherwise get the period 3 forecast of this day...
                   ?? Forecast.FirstOrDefault(w => w.Period == 3 && w.ForecastDate == day)
                   //if none of the above exist, get period 2 of next day
                   ?? Forecast.FirstOrDefault(w => w.Period == 2 && w.ForecastDate == day.AddDays(1));
        }
        
    }
}