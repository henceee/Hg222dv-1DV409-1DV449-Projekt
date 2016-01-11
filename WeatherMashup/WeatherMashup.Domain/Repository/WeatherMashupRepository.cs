using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WeatherMashup.Domain.Abstract;
using WeatherMashup.Domain.Entities;

namespace WeatherMashup.Domain.Repository
{
    public class WeatherMashupRepository : WeatherMashupRepositoryBase
    {
        private readonly WeathermashupEntities _context = new WeathermashupEntities();

        ///             WEATHER 
        #region Weather
        protected override IQueryable<Entities.Weather> QueryWeather()
        {
            return _context.Weather.AsQueryable();
        }

        public override void InsertWeather(Entities.Weather weather)
        {
            _context.Weather.Add(weather);
        }

        public override void UpdateWeather(Entities.Weather weather)
        {
            _context.Entry(weather).State = EntityState.Modified;
        }

        public override void DeleteWeather(int WeatherID)
        {
            var weather = _context.Weather.Find(WeatherID);
            _context.Weather.Remove(weather);
        }
        #endregion
        ///             LOCATION      
        #region Location
        protected override IQueryable<Entities.Location> QueryLocation()
        {
            return _context.Location.AsQueryable();
        }

        public override void InsertLocation(Entities.Location location)
        {
            _context.Location.Add(location);
        }

        public override void UpdateLocation(Entities.Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
        }

        public override void DeleteLocation(int LocationID)
        {
            var location = _context.Location.Find(LocationID);
            _context.Location.Remove(location);
        }
        #endregion
        ///             SAVE   
        #region Save
        public override void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                //do something
            }
       
                    
               
        }
        #endregion
        //              DISPOSE
        #region Dispose
        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;

            base.Dispose(disposing);
        }
        #endregion
    }
}