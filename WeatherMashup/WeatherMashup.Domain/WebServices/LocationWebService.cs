using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WeatherMashup.Domain.Datamodels.WeatherMashup;

namespace WeatherMashup.Domain.WebServices
{
    public class LocationWebService
    {
        //TODO: get a valid username 
        const string APIUsername = "demo";

        public IEnumerable<LocationModel> getLocationFromCityName(string cityName)
        {

            //http://api.geonames.org/searchJSON?name_equals=kalmar&maxRows=50&tags=city&username=demo
            var uriString = string.Format("http://api.geonames.org/searchJSON?name_equals={1}&maxRows=50&tags=city&username=&username={1}",
                                         cityName,APIUsername);
           /* var request = (HttpWebRequest)WebRequest.Create(uriString);
            request.Method = "GET";

            using (var response = request.GetResponse())
           using (var reader = new StreamReader(response.GetResponseStream()))*/
            string rawLocationJSON;

            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/GeonamesSampleData.txt")))
            {
                rawLocationJSON = reader.ReadToEnd();
            }

            var JSON = JObject.Parse(rawLocationJSON)["geonames"];
           var JSONString = JSON.ToString();
           return JArray.Parse(JSONString).Select(location => new LocationModel(location)).ToList();
        }
    }
}