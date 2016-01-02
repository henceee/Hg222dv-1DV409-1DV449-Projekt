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
        public IEnumerable<LocationModel> getLocationFromCityName(string cityName)
        {
            LocationWebServiceWrapper wrapper = new LocationWebServiceWrapper();

            var username = wrapper.getAuthentication();
            //TODO create wrapper help-class and add username in web config ?
            //http://api.geonames.org/searchJSON?name_equals=kalmar&maxRows=50&tags=city&username=demo
            var uriString = string.Format("http://api.geonames.org/searchJSON?name_equals={0}&maxRows=50&tags=city&username={1}",
                                         cityName,username);
            
            var request = (HttpWebRequest)WebRequest.Create(uriString);
            request.Method = "GET";

            string rawLocationJSON;

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawLocationJSON = reader.ReadToEnd();
            }

            #region sample data
            /*using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/GeonamesSampleData.txt")))
            {
                rawLocationJSON = reader.ReadToEnd();
            }*/
            #endregion
            //TODO sensative to changes, find workaround?           
            //TODO: add check if JSON data contains more than 1 or more obj.
            var JSON = JObject.Parse(rawLocationJSON)["geonames"];
            
                var JSONString = JSON.ToString();
                return JArray.Parse(JSONString).Select(location => new LocationModel(location)).ToList();
            
            
        }
    }
}