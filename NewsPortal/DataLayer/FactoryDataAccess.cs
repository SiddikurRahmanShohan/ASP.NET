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

        public static IRepository<Category, int> CategoryDataAccess() { return new CategoryRepo(db); }

    }
}
