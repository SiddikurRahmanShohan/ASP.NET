using API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Intro.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/student/get")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetAll()
        {
            /*List<Person> persons = new List<Person>();
            for (int i = 1; i <= 10; i++)
            {
                var p = new Person()
                {
                    Id = i,
                    Name = "Person" + i,
                };
                persons.Add(p);
            }
            var data = new JavaScriptSerializer().Serialize(persons);*/

            return Request.CreateResponse(HttpStatusCode.OK, "Ok");
        }

        [Route("api/student/create")]//coustom routing
        [HttpPost] //Bind for Post only
        public HttpResponseMessage Create(Student data)
        {
            /*List<Person> persons = new List<Person>();
            for (int i = 1; i <= 10; i++)
            {
                var p = new Person()
                {
                    Id = i,
                    Name = "Person" + i,
                };
                persons.Add(p);
            }
            var data = new JavaScriptSerializer().Serialize(persons);*/

            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

    }
}
