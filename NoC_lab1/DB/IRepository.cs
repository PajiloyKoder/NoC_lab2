using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1.DB
{
    public interface IRepository<V> where V : class 
    {
        V Get(int id);


        IEnumerable<V> GetSome(IEnumerable<int> ids);

        void Create(V item);

        void Update(V item);

        void Delete(int id);
    }
}
