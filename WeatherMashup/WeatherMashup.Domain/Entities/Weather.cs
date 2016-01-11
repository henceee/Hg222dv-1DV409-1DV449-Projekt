using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherMashup.Domain.Entities
{
    [MetadataType(typeof(Weather_MetaData))]
    public partial class Weather
    {      

        public Weather()
        {

        }

        public Weather(Location location)
        {
            LocationID = location.LocationID;
            Location = location;
        
        }

        private class Weather_MetaData
        {
            [HiddenInput(DisplayValue=false)]
            [Key]
            public int WeatherID {get;set;}
        }
    }
}