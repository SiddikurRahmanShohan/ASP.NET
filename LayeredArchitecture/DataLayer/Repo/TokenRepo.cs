using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public class TokenRepo
    {
        public static Token Add(Token obj)
        {
            UMSEntities db = new UMSEntities();
            var st = db.Tokens.Add(obj);
            return st;
        }

    }
}
