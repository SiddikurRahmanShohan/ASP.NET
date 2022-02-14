using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movierent.Models;

namespace Movierent.Controllers
{
	public class MoviesController : Controller
	{
		//
		// GET: /Movies/
		public ActionResult Index()
		{

           
		}


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Movie());
        }

        [HttpPost]
        public ActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                /*SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                connection.Open();
                string sql = "INSERT INTO Students(id,name,dob) VALUES('" + s.Id + "','" + s.Name + "','" + s.Dob + "')";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();*/
                return RedirectToAction("Index", "Movies", m);
            }
            return View(m);
        }


	}
}