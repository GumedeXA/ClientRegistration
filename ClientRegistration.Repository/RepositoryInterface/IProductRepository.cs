using System;
using System.Collections.Generic;
using ClientRegistration.Data.Entities;

namespace ClientRegistration.Repository.RepositoryInterface
{
    public interface IProductRepository
    {
        Product GetById(Int32 id);
        List<Product> GetAll();
        void Insert(Product model);
        void Update(Product model);
        void Delete(Product model);
        IEnumerable<Product> Find(Func<Product, bool> predicate);
    }
}
