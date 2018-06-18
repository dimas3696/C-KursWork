using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Create(string name);
        void Update(T item);
        void Delete(int id);
        void DeleteRefer(int idWhere, int idWhat);
        void AddRefer(int idWhere, int idWhat);
        T GetForName(string Name);
        IEnumerable<T> GetListForName(string Name);
        List<T> GetListFromId(int id);
        int GetLastId();
    }
}
