using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Entities;


namespace WeatherMashup.ViewModels
{
    public class LocationView
    {
        [Required(ErrorMessage = "Please input name of a city or location")]
        [DisplayName("location")]
        public string CityName { get; set; }


        public bool HasLocations { get { return Locations != null && Locations.Any(); } }

        public int Count { get { return HasLocations ? Locations.Count() : 0; } }

        public IEnumerable<Location> Locations { get; set; }

    }
}