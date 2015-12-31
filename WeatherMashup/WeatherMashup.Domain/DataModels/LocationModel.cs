using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.DataModels;

namespace WeatherMashup.Domain.Datamodels.WeatherMashup
{
    
    public class LocationModel
    {
        

        public LocationModel(JToken LocationToken)
        {
            Lat = LocationToken["lat"].ToString();
            Lng = LocationToken["lng"].ToString();
            CityName = LocationToken["name"].ToString();            
            Country = LocationToken["countryName"].ToString();
            ID = GetHashCode();
        }

        public int ID { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
      
        
    }
}