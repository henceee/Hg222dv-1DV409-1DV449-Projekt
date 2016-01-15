using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherMashup.Domain.Entities
{
    [MetadataType(typeof(Location_MetaData))]
    public partial class Location
    {
        
        public Location(JToken LocationToken)
            :this()
        {
            Lat      = LocationToken.Value<string>("lat");
            Long     = LocationToken.Value<string>("lng");
            CityName = LocationToken.Value<string>("name");            
            Country  = LocationToken.Value<string>("countryName");
            Region = LocationToken.Value<string>("adminName1");
           
        }

        private class Location_MetaData
        {
            [HiddenInput(DisplayValue = false)]
            [Key]
            public int LocationID { get; set; }
        }
      
        
    }
}