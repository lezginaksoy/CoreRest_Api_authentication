using ATM_Management_CoreRestApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_Management_CoreRestApi.Data.Interface
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected readonly AtmManagmentContext _context;

        public Repository(AtmManagmentContext Context)
        {
            _context = Context;
        }

        protected int Save() => _context.SaveChanges();

        public int Create(T entity)
        {
            _context.Add(entity);
            int RetVal = Save();
            return RetVal;

        }

        public virtual int Delete(T entity)
        {
            int RetVal = 0;
            _context.Remove(entity);
             RetVal = Save();
            return RetVal;
        }

        public virtual int Update(T entity)
        {
            int RetVal = 0;
            _context.Entry(entity).State = EntityState.Modified;
            RetVal = Save();
            return RetVal;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

   
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public int Count(Func<T, Boolean> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public bool Any(Func<T, bool> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public bool Any()
        {
            return _context.Set<T>().Any();
        }

    }
}
