using BusinessLayer.Entities;
using DataLayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StudentService
    {
        public static List<StudentEM> GetStudents()
        {
            var st = StudentRepo.GetStudents();
            List<StudentEM> student = new List<StudentEM>();
            foreach (var s in st)
            {
                var sd = new StudentEM()
                {
                    Id = s.Id,
                    Name = s.Name,
                    DeptId = s.DeptId
                };
                student.Add(sd);

            }

            return student;
        }
        public static StudentEM GetStudent(int id)
        {
            var st = StudentRepo.GetStudent(id);
            var s = new StudentEM()
            {
                Id = st.Id,
                Name = st.Name,
                DeptId = st.DeptId
            };

            return s;
        }
    }
}
