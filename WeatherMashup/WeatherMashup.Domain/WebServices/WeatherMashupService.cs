using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Abstract;
using WeatherMashup.Domain.Entities;
using WeatherMashup.Domain.Repository;

namespace WeatherMashup.Domain.WebServices
{
    public class WeatherMashupService : WeatherMashupServiceBase
    {
        private IWeatherMashupRepository _repository;
        
        public WeatherMashupService()
            :this(new WeatherMashupRepository())
        {

        }
        public WeatherMashupService(IWeatherMashupRepository repository)
        {
            _repository = repository;
        }


        public override IEnumerable<Location> getLocation(string cityName)
        {
            var locations = _repository.getLocationsByCityName(cityName);
            //If there are any locations...
            if (!locations.Any())
            {
                //get the locations from the webservice and...
                var locationWebService = new LocationWebService();
                //Iterate through all locations, insert them and save the repository changes to db.
                locationWebService.getLocationsByCityName(cityName).ToList().ForEach(l=>this._repository.InsertLocation(l));
                this._repository.Save();
            }

            return locations.ToList();
        }


        public override IEnumerable<Weather> getWeather(int locationID)
        {
            var location = _repository.GetLocationByID(locationID);
            //If there are no weather data, or it is time to update weather data....
            if (!location.Weather.Any() || location.Weather.First().NextUpdate < DateTime.Now)
            {
                //Delete old weather data (if there is any)...
                location.Weather.ToList().ForEach(w => this._repository.DeleteWeather(w.WeatherID));
                //Get the weather data from the weather webservice..
                var weatherWebService = new WeatherWebService();
                //Iterate through weather data, insert them and save the repository changes to db.
                weatherWebService.getWeather(location).ToList().ForEach(w=>this._repository.InsertWeather(w));
                this._repository.Save();
            }

            return location.Weather.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}