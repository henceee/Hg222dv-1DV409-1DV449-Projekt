using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WeatherMashup.Domain.DataModels;

namespace WeatherMashup.Domain.WebServices
{ 
    

    public class WeatherWebService
    {
        public IEnumerable<WeatherModel> getWeather(LocationModel location)
        {

            string uri = "http://www.yr.no/place/{location.Country}/{location.CityName}/{location.CityName}/forecast.xml";

            var request = (HttpWebRequest)WebRequest.Create(uri);

            #region testdata

            string rawXML = string.Empty;
            WeatherModel weather = new WeatherModel();
         

           /* using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))*/
            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath
                                      ("~/App_Data/YrNoSampleData.xml")))
            {
                rawXML = reader.ReadToEnd();
            }

            var doc = XDocument.Parse(rawXML);

            var model = (from time in doc.Descendants("time")
                         select new WeatherModel
                         {
                            //public int SymbolNumber { get; set; }
                            //public double Temperature { get; set; }
                            //public double PrecipitationMinValue { get; set; }
                            //public double PrecipitationMaxValue { get; set; }
                            //public DateTime Time { get; set; }


                         }).ToList();

            return model;
            #endregion
            
        }
    }
}