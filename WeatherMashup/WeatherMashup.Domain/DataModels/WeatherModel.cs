using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.DataModels
{
    
    public partial class WeatherModel
    {
        public DateTime ForecastDate { get; set; }
        public int Period { get; set; }
        public int SymbolNumber { get; set; }
        public double Precipitation { get; set; }
        public double Temperature { get; set; }      
        public string TempUnit { get; set; }
        public DateTime NextUpdate { get; set; }

    }
}