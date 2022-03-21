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
                var sdata = (from st in db.Students where st.DeptId == dep.Id select st).ToList();
                foreach(var s in sdata)
                {
                    StudentEM student = new StudentEM() { 
                        Id = s.Id,
                        Name = s.Name,
                        DeptId = s.DeptId,
                        DeptName = s.Department.Name,
                    };
                    department.Students.Add(student);

                }
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
