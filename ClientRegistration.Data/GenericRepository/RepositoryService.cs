using System;
using System.Data.Entity;
using System.Linq;

namespace ClientRegistration.Data.GenericRepository
{
    public class RepositoryService<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;


        private IDbSet<TEntity> Entities
        {
            get { return _context.Set<TEntity>(); }
        }

        public RepositoryService(DbContext context)
        {
            _context = context;

        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();


        }
        public void Delete(TEntity entity)
        {
            Entities.Attach(entity);
            Entities.Remove(entity);
            _context.SaveChanges();
        }



        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return Entities.Where(predicate).AsQueryable();
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
