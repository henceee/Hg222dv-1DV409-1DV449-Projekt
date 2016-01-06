using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.Entities
{
    
    public partial class Location
    {
        //denna är ungefär som user i Mats ex. ??

        public Location(JToken LocationToken)
            :this()
        {
            Lat = LocationToken.Value<string>("lat");
            Long = LocationToken.Value<string>("lng");
            CityName = LocationToken.Value<string>("name");            
            Country = LocationToken.Value<string>("countryName");
           
        }

       
      
        
    }
}