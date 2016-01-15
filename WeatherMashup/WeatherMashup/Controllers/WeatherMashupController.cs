using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherMashup.Domain;
using WeatherMashup.Domain.Abstract;
using WeatherMashup.Domain.WebServices;
using WeatherMashup.ViewModels;
using Vereyon.Web;

namespace WeatherMashup.Controllers
{
    public class WeatherMashupController : Controller
    {
        #region Fields
        private readonly IWeatherMashupService _service;
        #endregion
        #region Constructors
        public WeatherMashupController()
            :this(new WeatherMashupService())
        {

        }
        public WeatherMashupController (IWeatherMashupService service)
	    {
            _service = service;
	    }
        #endregion
        #region Index
        //
        // GET: /WeatherMashup/
        public ActionResult Index()
        {            
            return View("Index");
        }

        //
        // POST /Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include= "CityName")] WeatherMashupViewModel model)
        {
            //TODO FIX ENTITY FRAMEWORK BUG:
            //Entity Framework: “Store update, insert, or delete statement affected an unexpected number of rows(0)"
             try
            {
                if (ModelState.IsValid)
                {                    
                    model.Locations = _service.getLocation(model.CityName);
                   
                    //If there's more than one location, let the user pick.
                    if (model.HasLocations && model.Count > 1)
                     {                        
                         return View("Index",model);
                     }                     
                     //If locations isn't empty, it contains one location, so show it to user.
                     else if (model.HasLocations && model.Count ==1)
                     {
                         return RedirectToAction("ShowWeather", "WeatherMashup", new { PositionID = model.Locations.First().LocationID });
                     }
                    //Otherwise there's no matches, show message to user
                    FlashMessage.Danger("No locations where found.");
                                       
                }                
                return View("Index");
            }
            //something's gone wrong, catch and show to user.
            catch (Exception e)
            {                
               FlashMessage.Danger("Unable to find requested location.Please check your spelling."); 
            }

             return View("Index", model);
        }
        #endregion
        #region ShowWeather
        //
        //GET ShowWeather        
        public ActionResult ShowWeather(int? positionID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!positionID.HasValue)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    WeatherMashupViewModel model = new WeatherMashupViewModel();
                    model.Weather = _service.getWeather((int)positionID);
                    return View("Index", model);
                }

            }
            //something's gone wrong, catch and show to user.
            catch (Exception e)
            {
                FlashMessage.Danger("Unable to find requested weather data.Please check your spelling."); 
            }
            return View("");
        }
        #endregion
        #region Ajax
        [AjaxOnly]
        public ActionResult GetLocations(string term)
        {
            return Json(_service.getLocations(term), JsonRequestBehavior.AllowGet);
        }
        #endregion
      
        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }        
}
