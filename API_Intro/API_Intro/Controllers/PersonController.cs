using API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace API_Intro.Controllers
{
    public class PersonController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<Person> persons = new List<Person>();
            for (int i = 1; i <= 10; i++)
            {
                var p = new Person()
                {
                    Id = i,
                    Name = "Person" + i,
                };
                persons.Add(p);
            }
            var data = new JavaScriptSerializer().Serialize(persons);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
