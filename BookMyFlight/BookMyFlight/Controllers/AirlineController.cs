using BookMyFlight.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMyFlight.Controllers
{
    public class AirlineController : Controller
    {
        //
        // GET: /Airline/
        BookMyFlightEntities db = new BookMyFlightEntities();
        public ActionResult Index()
        {

            return View();
        }
	}
}