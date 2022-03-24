using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public class StudentRepo
    {
        public static List<Student> GetStudents()
        {
            UMSEntities db = new UMSEntities();
            var st = (from s in db.Students select s).ToList();
            return st;
        }
        public static Student GetStudent(int id)
        {
            UMSEntities db = new UMSEntities();
            var st = db.Students.Find(id);
            return st;
        }

        public static bool AddStudent(Student st)
        {
            UMSEntities db = new UMSEntities();
            db.Students.Add(st);
            var added = db.SaveChanges();
            if (added > 0) return true;
            return false;
        }
    }
}
