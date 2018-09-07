using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;

namespace ClientRegistration.BusinessLogic.Interfaces
{
    public interface ICustomerRegisterBusinessLogic
    {

        CustomerViewModel GetById(int id);
        void Insert(CustomerViewModel model);
        IEnumerable<CustomerViewModel> GetAllRegisteredUsers();
    }
}
