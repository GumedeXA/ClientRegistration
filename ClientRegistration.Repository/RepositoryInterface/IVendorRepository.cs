using ClientRegistration.Data.Entities;
using System;
using System.Collections.Generic;

namespace ClientRegistration.Repository.RepositoryInterface
{
    public interface IVendorRepository
    {
        Vendor GetById(Int32 id);
        List<Vendor> GetAll();
        void Insert(Vendor model);
        void Update(Vendor model);
        void Delete(Vendor model);
        IEnumerable<Vendor> Find(Func<Vendor, bool> predicate);
    }
}
