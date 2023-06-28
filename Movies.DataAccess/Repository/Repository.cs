using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Data;
using Movies.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace Movies.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContent _context;
        internal DbSet<T> dbset;

        public Repository(ApplicationDbContent context)
        {
            _context = context;
            this.dbset =_context.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);  
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = dbset;
            return query;
        }

        public T GetFirstordefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query =query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
           dbset.RemoveRange(entity);
        }
    }
}
