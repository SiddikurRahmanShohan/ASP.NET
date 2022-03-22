using API_CRUD.Models.Database;
using API_CRUD.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace API_CRUD.Controllers
{
    public class StudentController : ApiController
    {
        UMSEntities db = new UMSEntities();
        [Route("api/student/getstudents")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetStudents()
        {
            List<StudentEM> students = new List<StudentEM>();
            var sdata = db.Students.ToList();
            foreach (var st in sdata){
                StudentEM student = new StudentEM();
                student.Id = st.Id;
                student.Name = st.Name;
                student.DeptId = st.DeptId;
                student.DeptName = st.Department.Name;
                students.Add(student);
            }

            var data = new JavaScriptSerializer().Serialize(students);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/student/addstudent")]//coustom routing
        [HttpPost] //Bind for Post only
        public HttpResponseMessage AddStudent(Student student)
        {
            var si = db.Students.Add(student);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, (si.Name + " has been Added" + " ID: " + si.Id));
        }

        [Route("api/student/updatestudent/{id}")]//coustom routing
        [HttpPost] //Bind for Post only
        public HttpResponseMessage UpdateStudent(int id, Student student)
        {
            var st = db.Students.Find(id);
            student.Id = st.Id;
            st.Name = student.Name;
            st.DeptId = student.DeptId;
            db.Entry(st).CurrentValues.SetValues(student);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, (st.Id + " has been Updated"));
        }

        [Route("api/student/getstbyid/{id}")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetStudentById(int id)
        {
            StudentEM student = new StudentEM();
            var sdata = (from st in db.Students where st.Id == id select st).FirstOrDefault();
            student.Id = sdata.Id;
            student.Name = sdata.Name;
            student.DeptId = sdata.DeptId;

            var data = new JavaScriptSerializer().Serialize(student);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/student/deletestbyid/{id}")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage DeleteStudentById(int id)
        {
            var sdata = (from st in db.Students where st.Id == id select st).FirstOrDefault();
            db.Students.Remove(sdata);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, ("Name: "+sdata.Name+" ID: "+sdata.Id+" has been Deleted"));
        }
    }
}
