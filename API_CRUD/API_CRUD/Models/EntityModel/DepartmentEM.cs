using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD.Models.EntityModel
{
    public class DepartmentEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<StudentEM> Students { get; set; }
       public  List<StudentEM> Students { get; set; }
    }
}