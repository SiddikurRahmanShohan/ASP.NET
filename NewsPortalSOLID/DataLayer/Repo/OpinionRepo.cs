using DataLayer.Database;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public class OpinionRepo : IRepository<Opinion, int>, IOpinion<int>
    {
        private NewsPortalEntities db;
        public OpinionRepo(NewsPortalEntities db) { this.db = db; }
        public Opinion Add(Opinion obj)
        {
            var opn = db.Opinions.Add(obj);
            db.SaveChanges();
            return opn;
        }

        public Opinion Get(int id)
        {
            return db.Opinions.FirstOrDefault(x => x.OpinionId == id);
        }

        public List<Opinion> GetByNews(int nid)
        {
            var opns = (from o in db.Opinions where o.NewsId == nid select o).ToList();
            return opns;
        }

        public List<Opinion> Get()
        {
            return db.Opinions.ToList();
        }

        public bool Edit(Opinion obj)
        {
            var copn = db.Opinions.Find(obj.OpinionId);
            db.Entry(copn).CurrentValues.SetValues(obj);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }

        public bool Delete(int id)
        {
            var copn = db.Opinions.Find(id);
            db.Opinions.Remove(copn);
            int rowaff = db.SaveChanges();
            if (rowaff > 0) { return true; }
            return false;
        }
    }
}
