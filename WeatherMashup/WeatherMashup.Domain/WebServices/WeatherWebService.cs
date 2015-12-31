using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WeatherMashup.Domain.Datamodels.WeatherMashup;
using WeatherMashup.Domain.DataModels;



namespace WeatherMashup.Domain.WebServices
{    

    public class WeatherWebService
    {
        public IEnumerable<WeatherModel> getWeather(LocationModel location)
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
                var model = (from time in doc.Descendants("time")
                             select new WeatherModel
                             {
                                 Date = DateTime.ParseExact(time.Attribute("to").Value,
                                                            "ddd MMM dd", CultureInfo.InvariantCulture),
                                 Period = int.Parse(time.Attribute("period").Value),
                                 SymbolNumber = int.Parse(time.Element("symbol").Attribute("number").Value),
                                 Precipitation = double.Parse(time.Element("precipitation").Attribute("value").Value),
                                 Temperature = double.Parse(time.Element("temperature").Attribute("value").Value),
                                 TempUnit = time.Element("temperature").Attribute("unit").Value,

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