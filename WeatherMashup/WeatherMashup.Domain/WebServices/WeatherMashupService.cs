using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Datamodels.WeatherMashup;
using WeatherMashup.Domain.DataModels;

namespace WeatherMashup.Domain.WebServices
{
    public class WeatherMashupService
    {
        public WeatherMashupService()
        {
            //empty
        }

        public IEnumerable<LocationModel> getLocation(string cityName)
        {
            LocationWebService model = new LocationWebService();
            return model.getLocationFromCityName(cityName);
        }

        public IEnumerable<WeatherModel> getWeather(LocationModel location)
        {
            WeatherWebService model = new WeatherWebService();
            return model.getWeather(location);
        }
    }
}