//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherMashup.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Weather
    {
        public int WeatherID { get; set; }
        public System.DateTime ForecastDate { get; set; }
        public int Period { get; set; }
        public int SymbolNumber { get; set; }
        public double Percipitation { get; set; }
        public double Temperature { get; set; }
        public string TempUnit { get; set; }
        public System.DateTime NextUpdate { get; set; }
        public int LocationID { get; set; }
    
        public virtual Location Location { get; set; }
    }
}