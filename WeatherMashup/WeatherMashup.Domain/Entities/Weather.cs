using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.Entities
{
    
    public partial class Weather
    {
        //denna är som tweet i Mats ex.??
        //(fast utan token)

        public Weather()
        {

        }

        public Weather(Location location)
        {
            LocationID = location.LocationID;
            Location = location;
        
        }

    }
}