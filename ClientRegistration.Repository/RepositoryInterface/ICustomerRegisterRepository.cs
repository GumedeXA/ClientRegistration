using ClientRegistration.Data.Entities;
using System;
using System.Collections.Generic;

namespace ClientRegistration.Repository.RepositoryInterface
{
    public interface ICustomerRegisterRepository : IDisposable
    {
        Customer GetById(Int32 id);
        List<Customer> GetAll();
        void Insert(Customer model);
        void Update(Customer model);
        void Delete(Customer model);
        IEnumerable<Customer> Find(Func<Customer, bool> predicate);
    }
}
