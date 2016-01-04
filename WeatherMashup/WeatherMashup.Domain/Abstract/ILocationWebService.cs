using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.Domain.Abstract
{
    interface ILocationWebService :IDisposable
    {
        IEnumerable<Location> getLocationFromCityName(string cityname);
    }
}
