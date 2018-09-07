using ClientRegistration.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

using ClientRegistration.Data.GenericRepository;
using ClientRegistration.Repository.RepositoryInterface;
using ClientRegistration.Data.Entities;

namespace ClientRegistration.Repository.Repository
{
    public class CustomerRegisterRepository : ICustomerRegisterRepository, IDisposable
    {
        private DataContext _dataContext;
        private readonly IRepository<Customer> _registercustRepository;


        public CustomerRegisterRepository()
        {
            _dataContext = new DataContext();
            _registercustRepository = new RepositoryService<Customer>(_dataContext);
        }

        public void Delete(Customer model)
        {
            _registercustRepository.Delete(model);
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            return _registercustRepository.Find(predicate).ToList();
        }

        public List<Customer> GetAll()
        {
            return _registercustRepository.GetAll().ToList();
        }

        public Customer GetById(int id)
        {
            return _registercustRepository.GetById(id);
        }

        public void Insert(Customer model)
        {
            _registercustRepository.Insert(model);
        }

        public void Update(Customer model)
        {
            _registercustRepository.Update(model);
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
