using System;
using System.Collections.Generic;
using System.Linq;
using ClientRegistration.Data.Context;
using ClientRegistration.Data.GenericRepository;
using ClientRegistration.Data.Entities;
using ClientRegistration.Repository.RepositoryInterface;

namespace ClientRegistration.Repository.Repository
{
    public class VendorRepository : IVendorRepository, IDisposable
    {
        private DataContext _dataContext;
        private readonly IRepository<Vendor> _vendorRepository;


        public VendorRepository()
        {
            _dataContext = new DataContext();
            _vendorRepository = new RepositoryService<Vendor>(_dataContext);
        }
        public void Delete(Vendor model)
        {
            _vendorRepository.Delete(model);
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

        public IEnumerable<Vendor> Find(Func<Vendor, bool> predicate)
        {
            return _vendorRepository.Find(predicate).ToList();
        }

        public List<Vendor> GetAll()
        {
            return _vendorRepository.GetAll().ToList();
        }

        public Vendor GetById(int id)
        {
            return _vendorRepository.GetById(id);
        }

        public void Insert(Vendor model)
        {
            _vendorRepository.Insert(model);
        }

        public void Update(Vendor model)
        {
            _vendorRepository.Update(model);
        }
    }
}
