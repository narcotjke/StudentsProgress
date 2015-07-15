using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> where T:class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        void Dispose();
    }
}
