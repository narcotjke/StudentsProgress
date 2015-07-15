using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class GenericRepository<T>:IRepository<T> where T:class
    {
        private StudentProgressEntities DbContext { get; set; }
        private DbSet<T> DbSet {get;set;}

        public GenericRepository(StudentProgressEntities context) 
        {
            DbContext = context;
            DbSet = DbContext.Set<T>();
        }
        public void Create(T entity)
        {
            if(entity != null)
            {
                DbSet.Add(entity);
            }
        }

        public T Read(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            try 
            { 
                return DbSet;
            }
            catch
            {
                return null;
            }
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if(entity != null)
            {
                DbSet.Remove(entity);
            }
        }


        public void Delete(int id)
        {
            var t = DbSet.Find(id);
            if (t != null)
                DbSet.Remove(t);
        }
    }
}
