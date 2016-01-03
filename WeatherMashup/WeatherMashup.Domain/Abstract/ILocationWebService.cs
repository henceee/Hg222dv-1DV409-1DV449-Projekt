using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMashup.Domain.Datamodels.WeatherMashup;

namespace WeatherMashup.Domain.Abstract
{
    interface ILocationWebService :IDisposable
    {
        IEnumerable<LocationModel> getLocationFromCityName(string cityname);
    }
}
