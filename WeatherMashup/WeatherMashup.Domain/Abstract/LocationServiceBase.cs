using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.Domain.Abstract
{
    public abstract class LocationServiceBase :ILocationWebService
    {
        #region ILocationWebService members
        public abstract IEnumerable<Location> getLocationFromCityName(string cityname);

        #endregion

        #region IDisposable Members

        public virtual void Dispose(bool disposing)
        {
           
        }

        public void Dispose()
        {
            Dispose(true /*disposing*/);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}