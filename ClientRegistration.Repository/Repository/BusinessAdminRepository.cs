using ClientRegistration.Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using ClientRegistration.Data.Entities;
using ClientRegistration.Data.GenericRepository;
using ClientRegistration.Data.Context;

namespace ClientRegistration.Repository.Repository
{
    public class BusinessAdminRepository : IBusinessAdminRepository, IDisposable
    {
        private DataContext _dataContext;
        private readonly IRepository<BusinessAdmin> _BusinessAdRepository;

        public BusinessAdminRepository()
        {
            _dataContext = new DataContext();
            _BusinessAdRepository = new RepositoryService<BusinessAdmin>(_dataContext);
        }

        public void Delete(BusinessAdmin model)
        {
            _BusinessAdRepository.Delete(model);
        }

        public IEnumerable<BusinessAdmin> Find(Func<BusinessAdmin, bool> predicate)
        {
            return _BusinessAdRepository.Find(predicate).ToList();
        }

        public List<BusinessAdmin> GetAll()
        {
           return _BusinessAdRepository.GetAll().ToList();
        }

        public BusinessAdmin GetById(int id)
        {
            return _BusinessAdRepository.GetById(id);
        }

        public void Insert(BusinessAdmin model)
        {
            _BusinessAdRepository.Insert(model);
        }

        public void Update(BusinessAdmin model)
        {
            _BusinessAdRepository.Update(model);
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
