using DataLayer.Database;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public class CategoryRepo : IRepository<Category, int>
    {
        private NewsPortalEntities db;
        public CategoryRepo(NewsPortalEntities db) { this.db = db; }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryId == id);
        }
        public Category Add(Category obj)
        {

            var cat = db.Categories.Add(obj);
            db.SaveChanges();
            return cat;
        }

        public bool Edit(Category obj)
        {
            var ccat = db.Categories.Find(obj.CategoryId);
            db.Entry(ccat).CurrentValues.SetValues(obj);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }

        public bool Delete(int id)
        {
            var ccat = db.Categories.Find(id);
            db.Categories.Remove(ccat);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }


    }
}
