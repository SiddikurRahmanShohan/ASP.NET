
using BookMyFlight.Models.Database;
using BookMyFlight.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        BookMyFlightEntities db = new BookMyFlightEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult AirlineRegister()
        {
            return View(new AirlineRegisterViewModel());
        }

        [HttpPost]
        public ActionResult AirlineRegister(AirlineRegisterViewModel alrvm)
        {
            if (ModelState.IsValid)
            {
                Airline al = new Airline();
                al.airline_name = alrvm.airline_name;
                al.airline_regno = alrvm.airline_regno;
                al.airline_address = alrvm.airline_address;
                al.airline_phone = alrvm.airline_phone;
                al.airline_status = "Pending";
                db.Airlines.Add(al);
                db.SaveChanges();
                Login lg = new Login();
                lg.airline_id = (from als in db.Airlines where (als.airline_phone == alrvm.airline_phone && als.airline_regno == alrvm.airline_regno) select als.airline_id).FirstOrDefault();
                lg.username = alrvm.username;
                lg.password = alrvm.password;
                lg.recovery_phone = alrvm.recovery_phone;
                lg.email = lg.email;
                lg.user_type = "airline";
                db.Logins.Add(lg);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(alrvm);
        }
        [HttpGet]
        public ActionResult Login()
        {
            //if (User.Identity.IsAuthenticated) 
            //return RedirectToAction("Login");
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login user)
        {
            var ldata = (from l in db.Logins
                        where l.password.Equals(user.password) &&
                        l.username.Equals(user.username)
                        select l).FirstOrDefault();
            if (ldata != null)
            {
                if (ldata.user_type == "airlines")
                {
                    var adata = (from a in db.Airlines
                            where a.airline_id == ldata.airline_id &&
                            a.airline_status.Equals("valid")
                            select a).FirstOrDefault();
                    if (adata != null)
                    {
                        return RedirectToAction("Index", "Airline");
                    }
                    else 
                    {
                        TempData["msg"] = "Your Request is Pending";
                        return RedirectToAction("Login");
                    }
                }
                else if (ldata.user_type == "customer")
                {
                    var cdata = (from c in db.Customers
                                 where c.customer_id == ldata.customer_id &&
                                 c.customer_status.Equals("valid")
                                 select c).FirstOrDefault();
                    if (cdata != null)
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                    else
                    {
                        TempData["msg"] = "Your Membership Is Temporary Blocked";
                        return RedirectToAction("Login");
                    }
                }
                else 
                {
                }
            }
            TempData["msg"] = "Invalid Crdentials";
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}