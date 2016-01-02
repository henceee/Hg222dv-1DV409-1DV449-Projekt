using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WeatherMashup.Domain.WebServices
{
    public class LocationWebServiceWrapper
    {
        public string getAuthentication()
        {
            return ConfigurationManager.AppSettings["GeonamesAuthorization"];
        }
    }
}