using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace PresentationAPI.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/student/getstbyid/{id}")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetStudentById(int id)
        {
            var st = BusinessLayer.Services.StudentService.GetStudent(id);

            var data = new JavaScriptSerializer().Serialize(st);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/student/getstudents")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetStudents()
        {
            var st = BusinessLayer.Services.StudentService.GetStudents();

            var data = new JavaScriptSerializer().Serialize(st);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
