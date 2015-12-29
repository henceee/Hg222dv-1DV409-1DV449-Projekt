using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.DataModels
{
    
    public class WeatherModel
    {  
        public int SymbolNumber { get; set; }
        public double Temperature { get; set; }
        public double PrecipitationMinValue { get; set; }
        public double PrecipitationMaxValue { get; set; }
        public DateTime Time { get; set; }
    }
}