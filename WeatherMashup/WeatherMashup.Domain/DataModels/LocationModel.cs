using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.DataModels;

namespace WeatherMashup.Domain
{
    
    public class LocationModel
    {
        

        public LocationModel(JToken LocationToken)
        {
            Lat = LocationToken["geonames"]["lat"].ToString();
            Lng = LocationToken["geonames"]["lng"].ToString();
            CityName = LocationToken["geonames"]["name"].ToString();            
            Country = LocationToken["geonames"]["countryName"].ToString();

        }

        public string Lat { get; set; }
        public string Lng { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
       // public virtual ICollection<WeatherModel> Weather { get; set; }
        
    }
}