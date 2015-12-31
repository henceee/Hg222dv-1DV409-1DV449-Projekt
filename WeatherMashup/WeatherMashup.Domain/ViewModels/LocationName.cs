using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.ViewModels
{
    public class LocationName
    {
        [Required(ErrorMessage = "Please input name of a city or location")]
        [DisplayName("location")]
        public string Name { get; set; }
    }
}