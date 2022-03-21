using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD.Models.EntityModel
{
    public class StudentEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }

        public string DeptName { get; set; }
    }
}