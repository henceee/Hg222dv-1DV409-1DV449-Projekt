using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherMashup.Domain;
using WeatherMashup.Domain.Datamodels.WeatherMashup;
using WeatherMashup.Domain.WebServices;
using WeatherMashup.ViewModels;
using Vereyon.Web;

namespace WeatherMashup.Controllers
{
    public class WeatherMashupController : Controller
    {
        
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
             try
            {
                if (ModelState.IsValid)
                {
                    var locationWebService = new LocationWebService();
                    model.Locations = locationWebService.getLocationFromCityName(model.Name);
                    //If there's more than one location, let the user pick.
                     if (model.Count > 1)
                     {                        
                         return View("ViewLocations",model);
                     }
                         //TODO this doesn't seem to work right, I don't think... 
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
        public ActionResult ShowWeather(int? PositionID)
        { 
           
            if (!PositionID.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //TODO add repo and get location name, use to get weather     
            return View("");
        }   
    }
}
