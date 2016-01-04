using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WeatherMashup.Domain.Entities;


namespace WeatherMashup.Domain.WebServices
{    

    public class WeatherWebService
    {
        public IEnumerable<Weather> getWeather(Location location)
        {
            
            string uriString = string.Format("http://www.yr.no/place/{0}/{1}/{1}/forecast.xml",
                                            location.Country,location.CityName,location.CityName);
            string rawXML = string.Empty;

            /*var request = (HttpWebRequest)WebRequest.Create(uriString);
            request.Method = "GET";            
            
           /* using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))*/
            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath
                                      ("~/App_Data/YrNoSampleData.xml")))
            {
                rawXML = reader.ReadToEnd();
            }

            var doc = XDocument.Parse(rawXML);

            
            try
            {
                var model = (from weatherdata in doc.Descendants("weatherdata")
                             select new Weather(location)
                             {
                                 NextUpdate = DateTime.ParseExact(weatherdata.Element("meta").Element("nextupdate").Value,
                                                                    "ddd MMM dd", CultureInfo.InvariantCulture),
                                 ForecastDate = DateTime.ParseExact(weatherdata.Element("time").Attribute("to").Value,
                                                            "ddd MMM dd", CultureInfo.InvariantCulture),
                                 Period = int.Parse(weatherdata.Element("time").Attribute("period").Value),
                                 SymbolNumber = int.Parse(weatherdata.Element("time").Element("symbol").Attribute("number").Value),
                                 Percipitation = double.Parse(weatherdata.Element("time").Element("precipitation").Attribute("value").Value),
                                 Temperature = double.Parse(weatherdata.Element("time").Element("temperature").Attribute("value").Value),
                                 TempUnit = weatherdata.Element("time").Element("temperature").Attribute("unit").Value,                                 

                             }).ToList();

                return model;
            }
            catch (Exception)
            {
                
                throw new ApplicationException("Internal error handling weather data.");
            }            
            
        }
    }
}