using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_Management_CoreRestApi.Data.Interface
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        int Create(T entity);

        int Update(T entity);

        int Delete(T entity);

        int Count(Func<T, bool> predicate);

        bool Any(Func<T, bool> predicate);

        bool Any();

    }
}
