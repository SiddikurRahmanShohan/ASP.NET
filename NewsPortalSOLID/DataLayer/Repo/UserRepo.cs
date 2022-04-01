using DataLayer.Database;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public class UserRepo : IRepository<User, int>
    {
        private NewsPortalEntities db;
        public UserRepo(NewsPortalEntities db) { this.db = db; }
        public User Add(User obj)
        {
            var usr = db.Users.Add(obj);
            db.SaveChanges();
            return usr;
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(x => x.UserId == id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public bool Edit(User obj)
        {
            var cusr = db.Users.Find(obj.UserId);
            db.Entry(cusr).CurrentValues.SetValues(obj);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }

        public bool Delete(int id)
        {
            var cusr = db.Users.Find(id);
            db.Users.Remove(cusr);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }
    }
}
