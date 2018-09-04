using ClientRegistration.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ClientRegistration.Data.GenericRepository;
using ClientRegistration.Repository.RepositoryInterface;
using ClientRegistration.Data.Entities;

namespace ClientRegistration.Repository.Repository
{
    public class RegisterRepository : IRegisterRepository, IDisposable
    {
        private DataContext _dataContext;
        private readonly IRepository<Register> _registerRepository;


        public RegisterRepository()
        {
            _dataContext = new DataContext();
            _registerRepository = new RepositoryService<Register>(_dataContext);
        }

        public void Delete(Register model)
        {
            _registerRepository.Delete(model);
        }

        public IEnumerable<Register> Find(Func<Register, bool> predicate)
        {
            return _registerRepository.Find(predicate).ToList();
        }

        public List<Register> GetAll()
        {
            return _registerRepository.GetAll().ToList();
        }

        public Register GetById(int id)
        {
            return _registerRepository.GetById(id);
        }

        public void Insert(Register model)
        {
            _registerRepository.Insert(model);
        }

        public void Update(Register model)
        {
            _registerRepository.Update(model);
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
