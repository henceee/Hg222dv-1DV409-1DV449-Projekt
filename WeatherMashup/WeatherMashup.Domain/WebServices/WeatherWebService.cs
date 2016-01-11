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

                     var nextUpdate = DateTime.Parse(doc.Element("weatherdata").Element("meta").Element("nextupdate").Value,
                                      CultureInfo.InvariantCulture);
                    
                     return (from time in doc.Descendants("time")                                    
                                  select new Weather(location)
                                  {                                      
                                      NextUpdate = nextUpdate,
                                      ForecastDate = DateTime.Parse(time.Attribute("from").Value,
                                                                CultureInfo.InvariantCulture),
                                      Period = int.Parse(time.Attribute("period").Value),
                                      SymbolNumber = int.Parse(time.Element("symbol").Attribute("number").Value),
                                      Percipitation = Convert.ToDouble(time.Element("precipitation").Attribute("value").Value,
                                                                       CultureInfo.InvariantCulture),
                                      Temperature = Convert.ToDouble(time.Element("temperature").Attribute("value").Value,
                                                                     CultureInfo.InvariantCulture),
                                      TempUnit = time.Element("temperature").Attribute("unit").Value,  
                                  }).ToList();
                    }
                

            }                                
                           
            catch (Exception e)
            {
                
                throw new ApplicationException("Internal error handling weather data.");
            }            
            
        }
    }
}