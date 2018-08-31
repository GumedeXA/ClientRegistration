using Wave28.Data.Entities;
using System;
using System.Collections.Generic;

namespace Wave28.Repository.RepositoryInterface
{
    public interface IRegisterRepository : IDisposable
    {
        Register GetById(Int32 id);
        List<Register> GetAll();
        void Insert(Register model);
        void Update(Register model);
        void Delete(Register model);
        IEnumerable<Register> Find(Func<Register, bool> predicate);
    }
}
