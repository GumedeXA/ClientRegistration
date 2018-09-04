using ClientRegistration.Data.Entities;
using System;
using System.Collections.Generic;

namespace ClientRegistration.Repository.RepositoryInterface
{
    public interface IBusinessAdminRepository
    {
        BusinessAdmin GetById(Int32 id);
        List<BusinessAdmin> GetAll();
        void Insert(BusinessAdmin model);
        void Update(BusinessAdmin model);
        void Delete(BusinessAdmin model);
        IEnumerable<BusinessAdmin> Find(Func<BusinessAdmin, bool> predicate);
    }
}
