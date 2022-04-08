using DataLayer.Database;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public class NewsRepo : IRepository<News, int>, ISearch<string, DateTime>
    {
        private NewsPortalEntities db;
        public NewsRepo(NewsPortalEntities db) { this.db = db; }
        public News Add(News obj)
        {
            var nws = db.Newses.Add(obj);
            db.SaveChanges();
            return nws;
        }

        public News Get(int id)
        {
            return db.Newses.FirstOrDefault(x => x.NewsId == id);
        }

        public List<News> Get()
        {
            return db.Newses.ToList();
        }

        public List<News> GetNewsByCatDate(string cat, DateTime dat)
        {
            var result = (from n in db.Newses where (n.Category.CategoryName.Contains(cat) && n.PostDate.Equals(dat)) select n).ToList();
            return result;
        }

        public List<News> GetNewsByCat(string cat)
        {
            var result = (from n in db.Newses where n.Category.CategoryName.Contains(cat) select n).ToList();
            return result;
        }

        public List<News> GetNewsByDate(DateTime dat)
        {
            var result = (from n in db.Newses where n.PostDate.Equals(dat) select n).ToList();
            return result;
        }

        public bool Edit(News obj)
        {
            var cnws = db.Newses.Find(obj.NewsId);
            db.Entry(cnws).CurrentValues.SetValues(obj);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }

        public bool Delete(int id)
        {
            var cnws = db.Newses.Find(id);
            db.Newses.Remove(cnws);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }
    }
}
