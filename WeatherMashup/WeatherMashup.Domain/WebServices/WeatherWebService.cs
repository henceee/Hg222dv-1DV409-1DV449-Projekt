using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WeatherMashup.Domain.Entities;


namespace WeatherMashup.Domain.WebServices
{    

    public class WeatherWebService
    {
        public IEnumerable<Weather> getWeather(Location location)
        {
            
            string uriString = string.Format("http://www.yr.no/place/{0}/{1}/{1}/forecast.xml",
                                            location.Country,location.CityName,location.CityName);
            List<Weather> weatherList = new List<Weather>();


            var request = (HttpWebRequest)WebRequest.Create(uriString);
            request.Method = "GET";            
            
           try
           {
                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
               /* using (var reader = new StreamReader(HttpContext.Current.Server.MapPath
                                          ("~/App_Data/YrNoSampleData.xml")))*/
                {
                    //IEnumerable<XElement> weatherData =
                     var doc = XDocument.Load(reader);
 
                     weatherList = (from weatherdata in doc.Elements("weatherdata")                                    
                                  select new Weather(location)
                                  {                                      
                                      NextUpdate = DateTime.Parse(weatherdata.Element("meta").Element("nextupdate").Value,
                                      CultureInfo.InvariantCulture),
                                      ForecastDate = DateTime.Parse(weatherdata.Element("forecast").Element("tabular").Element("time").Attribute("to").Value,
                                                                CultureInfo.InvariantCulture),
                                      Period = int.Parse(weatherdata.Element("forecast").Element("tabular").Element("time").Attribute("period").Value),
                                      SymbolNumber = int.Parse(weatherdata.Element("forecast").Element("tabular").Element("time").Element("symbol").Attribute("number").Value),
                                      Percipitation = double.Parse(weatherdata.Element("forecast").Element("tabular").Element("time").Element("precipitation").Attribute("value").Value),
                                      Temperature = double.Parse(weatherdata.Element("forecast").Element("tabular").Element("time").Element("temperature").Attribute("value").Value),
                                      TempUnit = weatherdata.Element("forecast").Element("tabular").Element("time").Element("temperature").Attribute("unit").Value,  
                                  }).ToList();
                

                }

                return weatherList;                               
               
            }
            catch (Exception e)
            {
                
                throw new ApplicationException("Internal error handling weather data.");
            }            
            
        }
    }
}