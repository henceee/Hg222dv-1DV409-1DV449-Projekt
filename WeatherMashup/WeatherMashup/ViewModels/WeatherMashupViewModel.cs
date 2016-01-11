using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Entities;


namespace WeatherMashup.ViewModels
{
    public class WeatherMashupViewModel
    {
        [Required(ErrorMessage = "Please input name of a city or location")]
        [DisplayName("location")]
        public string CityName { get; set; }
        public string City { get { return Weather.FirstOrDefault().Location.CityName ?? Locations.FirstOrDefault().CityName; } }      


        public bool HasLocations { get { return Locations != null && Locations.Any(); } }

        public int Count { get { return HasLocations ? Locations.Count() : 0; } }

        public IEnumerable<Location> Locations { get; set; }


        public bool HasWeather { get { return Weather != null && Weather.Any(); } }

        public IEnumerable<Domain.Entities.Weather> Weather { get; set; }


        public IEnumerable<Weather> Forecast
        {
            get
            {
                List<Weather> forecast = new List<Weather>();

                for (int i = 0; i < 4; i++)
                {
                    DateTime weatherdate = DateTime.Today.AddDays(i);
                    int day = weatherdate.Day;
                    //if there is a forecast for period 2 of this day, use it...
                    var weather = Weather.FirstOrDefault(w => w.Period == 2 && w.ForecastDate.Day == day)
                    //otherwise get the period 3 forecast of this day...
                                ?? Weather.FirstOrDefault(w => w.Period == 3 && w.ForecastDate.Day == day)
                    //if none of the above exist, get period 2 of next day
                                ?? Weather.FirstOrDefault(w => w.Period == 2 && w.ForecastDate.Day == weatherdate.AddDays(1).Day);
                    if (weather != null)
                    {
                        forecast.Add(weather);
                    }
                }

                return forecast;
            }
        }

    }
}