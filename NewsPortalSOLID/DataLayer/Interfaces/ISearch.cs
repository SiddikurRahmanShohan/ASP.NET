using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ISearch<Cat, Dat>
    {
        List<News> GetNewsByCatDate(Cat cat, Dat dat);
        List<News> GetNewsByCat(Cat cat);

        List<News> GetNewsByDate(Dat dat);
    }
}
