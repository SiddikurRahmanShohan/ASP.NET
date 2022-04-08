using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FactoryDataAccess
    {
        static NewsPortalEntities db = new NewsPortalEntities();

        public static IRepository<User, int> UserDataAccess() { return new UserRepo(db); }
        public static IRepository<Category, int> CategoryDataAccess() { return new CategoryRepo(db); }
        public static IRepository<News, int> NewsDataAccess() { return new NewsRepo(db); }

        public static ISearch<string, DateTime> SearchNews() { return new NewsRepo(db); }

        public static IRepository<Opinion, int> OpinionDataAccess() { return new OpinionRepo(db); }
        public static IOpinion<int> NewsOpinionDataAccess() { return new OpinionRepo(db); }
    }
}
