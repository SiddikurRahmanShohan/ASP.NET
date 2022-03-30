using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepository<T, ID>
    {
        T Add(T obj);
        T Get(ID id);
        List<T> Get();
        bool Edit(T obj);
        bool Delete(ID id);
    }
}
