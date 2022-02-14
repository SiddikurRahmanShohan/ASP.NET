using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Test1.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult Create()
        {
            return View( new Student());
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                connection.Open();
                string sql = "INSERT INTO Students(id,name,dob) VALUES('" + s.Id + "','" + s.Name + "','" + s.Dob + "')";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return RedirectToAction("StudentList","Student");
            }
            return View(s);
        }
        public ActionResult StudentList()
        {
            return View();
        }
	}
}