using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12.Repository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); //objects
        T Get(int id);
        void Create(T item);
        void Update(T itemOld, T itemNew);
        void Delete(int id);
    }
}
