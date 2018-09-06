using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;

namespace ClientRegistration.BusinessLogic.Interfaces
{
    public interface ICustomerRegisterBusinessLogic
    {
    
        RegisterViewModel GetById(int id);
        void Insert(RegisterViewModel model);
        IEnumerable<RegisterViewModel> GetAllRegisteredUsers();
    }
}
