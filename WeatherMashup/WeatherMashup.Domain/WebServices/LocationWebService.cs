﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.Domain.WebServices
{
    public class LocationWebService
    {
        public IEnumerable<Location> getLocationsByCityName(string cityName)
        {
            LocationWebServiceWrapper wrapper = new LocationWebServiceWrapper();

            var username = wrapper.getAuthentication();           
            //                              api.geonames.org/searchJSON?name_equals=kalmar&maxRows=50&tags=city&username=hg222dv
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
     
            var JSON = JObject.Parse(rawLocationJSON)["geonames"];
            
                var JSONString = JSON.ToString();
                return JArray.Parse(JSONString).Select(location => new Location(location)).ToList();
            
            
        }
    }
}