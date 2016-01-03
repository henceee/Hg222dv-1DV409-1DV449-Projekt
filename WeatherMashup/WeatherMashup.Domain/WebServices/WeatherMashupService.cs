using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Abstract;
using WeatherMashup.Domain.Datamodels.WeatherMashup;
using WeatherMashup.Domain.DataModels;

namespace WeatherMashup.Domain.WebServices
{
    public class WeatherMashupService : WeatherMashupServiceBase
    {
        public WeatherMashupService()
        {
            //empty
        }



        public override IEnumerable<LocationModel> getLocation(string cityName)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<WeatherModel> getWeather(LocationModel location)
        {
            throw new NotImplementedException();
        }
    }
}