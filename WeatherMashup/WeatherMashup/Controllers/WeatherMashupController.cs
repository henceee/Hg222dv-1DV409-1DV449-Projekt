using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherMashup.Domain;
using WeatherMashup.Domain.WebServices;
using WeatherMashup.Domain.ViewModels;

namespace WeatherMashup.Controllers
{
    public class WeatherMashupController : Controller
    {
        //
        // GET: /WeatherMashup/
        public ActionResult Index()
        {  
           //DO SOMETHING.
            return View("Index");

        }

        //
        // POST /WeatherMashup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include= "")] LocationName model)
        {
             try
            {
                if (ModelState.IsValid)
                {
                    var locationWebService = new LocationWebService();
                    var locations = locationWebService.getLocationFromCityName(model.Name);
 
                     if (locations.Count() > 1)
                     {
                        
                         return View("ViewLocations",locations);
                     }
                    
                     else if (locations.Any())
                     {
                         return View("Forecast", locations.First().ID);
                     }
                    //Otherwise there's no matches, show message to user
                    TempData["Error"] = "No locations where found.";
                     
                    return View("Index");
                }                
                return View("Index");
            }
            //something's done goofed.
            catch (Exception e)
            {
                TempData["Error"] = "Internal error. Please try again or contact admin.";
                return View("Index"); 
            }            
        }
       

    }
}
