using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Siscream.Interfaces
{
    interface IDAO<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> List();
        T GetByID(int id);
    }
}
