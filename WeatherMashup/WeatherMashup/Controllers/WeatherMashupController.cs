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
        private IWeatherMashupService _service;

        public WeatherMashupController()
            :this(new WeatherMashupService())
        {

        }
        public WeatherMashupController (IWeatherMashupService service)
	    {
            _service = service;
	    }
        //
        // GET: /WeatherMashup/
        public ActionResult Index()
        {            
            return View("Index");
        }

        //
        // POST /WeatherMashup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include= "Name")] LocationName model)
        {
            //TODO FIX ENTITY FRAMEWORK BUG:
            //Entity Framework: “Store update, insert, or delete statement affected an unexpected number of rows
             try
            {
                if (ModelState.IsValid)
                {                    
                    model.Locations = _service.getLocation(model.Name);
                    //If there's more than one location, let the user pick.
                     if (model.Count > 1)
                     {                        
                         return View("ViewLocations",model);
                     }                     
                     //If locations isn't empty, it contains one location, so show it to user.
                     else if (model.HasLocations)
                     {   
                         return View("ShowWeather", model.Locations.First().LocationID);
                     }
                    //Otherwise there's no matches, show message to user
                    FlashMessage.Danger("No locations where found.");
                                       
                }                
                return View("Index");
            }
            //something's gone wrong, catch and show to user.
            catch (Exception e)
            {
                //TODO get freaking flashmessage to show -.-
                FlashMessage.Danger("Unable to find requested location.Please check your spelling."); 
            }

             return View("Index", model);
        }

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
                    var weatherData = _service.getWeather((int)positionID);         
                    return View("ShowWeather",weatherData);
                }
               
            }
            //something's gone wrong, catch and show to user.
            catch (Exception e)
            {
                      
            }
             return View("");
        }   
    }
}
