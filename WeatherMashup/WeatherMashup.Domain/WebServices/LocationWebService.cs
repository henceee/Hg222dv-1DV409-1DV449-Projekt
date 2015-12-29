using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.WebServices
{
    public class LocationWebService
    {
        public IEnumerable<LocationModel> getLocation(double lat,double lng)
        {

            //http://api.geonames.org/findNearbyPlaceNameJSON?lat=47.3&lng=9&username=demo

            string rawLocationJSON;

            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/GeonamesSampleData.txt")))
            {
                rawLocationJSON = reader.ReadToEnd();
            }

           return JArray.Parse(rawLocationJSON).Select(t => new LocationModel(t)).ToList();
        }
    }
}