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
    public class DepartmentController : ApiController
    {
        UMSEntities db = new UMSEntities();
        [Route("api/department/getdepartments")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetDepartments()
        {
            List<DepartmentEM> departments = new List<DepartmentEM>();
            var ddata = db.Departments.ToList();
            foreach (var dep in ddata)
            {
                DepartmentEM department = new DepartmentEM();
                department.Id = dep.Id;
                department.Name = dep.Name;
                var sdata = (from st in db.Students where st.DeptId.Equals(dep.Id) select st).ToList();
                List<StudentEM> students = new List<StudentEM>();
                foreach(var s in sdata)
                {
                    StudentEM student = new StudentEM();
                    student.Id = s.Id;
                    student.Name = s.Name;
                    student.DeptId = s.DeptId;
                    student.DeptName = s.Department.Name;
                    students.Add(student);

                }
                department.Students = students;
                departments.Add(department);
            }

            var data = new JavaScriptSerializer().Serialize(departments);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/department/getdeptbyid/{id}")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage GetDepartmentById(int id)
        {
            DepartmentEM department = new DepartmentEM();
            var ddata = (from dep in db.Departments where dep.Id == id select dep).FirstOrDefault();
            department.Id = ddata.Id;
            department.Name = ddata.Name;

            var data = new JavaScriptSerializer().Serialize(department);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/department/adddepartment")]//coustom routing
        [HttpPost] //Bind for Post only
        public HttpResponseMessage AddDepartment(Department department)
        {
            var di = db.Departments.Add(department);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, (di.Name +" has been Added"+" ID: "+di.Id));
        }

        [Route("api/department/updatedepartment/{id}")]//coustom routing
        [HttpPost] //Bind for Post only
        public HttpResponseMessage UpdateDepartment(int id, Department department)
        {
            var dep = db.Departments.Find(id);
            department.Id = dep.Id;
            dep.Name = department.Name;
            db.Entry(dep).CurrentValues.SetValues(department);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, (dep.Id + " has been Updated"));
        }

        [Route("api/department/deletedeptbyid/{id}")]//coustom routing
        [HttpGet] //Bind for Get only
        public HttpResponseMessage DeleteDepartmentById(int id)
        {
            var ddata = (from dep in db.Departments where dep.Id == id select dep).FirstOrDefault();
            db.Departments.Remove(ddata);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, ("Name: " + ddata.Name + " ID: " + ddata.Id + " has been Deleted"));
        }
    }
}
