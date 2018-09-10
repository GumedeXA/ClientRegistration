using System;
using System.Linq;
using System.Collections.Generic;
using ClientRegistration.Data.Entities;
using ClientRegistration.Repository.RepositoryInterface;
using ClientRegistration.Data.GenericRepository;
using ClientRegistration.Data.Context;

namespace ClientRegistration.Repository.Repository
{
    public class ProductRepository : IProductRepository, IDisposable
    {

        private DataContext _dataContext;
        private readonly IRepository<Product> _prodRepository;

        public ProductRepository()
        {
            _dataContext = new DataContext();
            _prodRepository = new RepositoryService<Product>(_dataContext);
        }
        
        public void Delete(Product model)
        {
           _prodRepository.Delete(model);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _prodRepository.Find(predicate).ToList();
        }

        public List<Product> GetAll()
        {
           return _prodRepository.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _prodRepository.GetById(id);
        }

        public void Insert(Product model)
        {
            _prodRepository.Insert(model);
        }

        public void Update(Product model)
        {
            _prodRepository.Update(model);
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
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    _dataContext = null;
                }
            }
        }
    }
}
