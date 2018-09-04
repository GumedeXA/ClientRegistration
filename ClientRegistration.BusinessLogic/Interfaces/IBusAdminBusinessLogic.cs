using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;


namespace ClientRegistration.BusinessLogic.Interfaces
{
    public interface IBusAdminBusinessLogic
    {
        RegisterViewModel GetBusinessAdminByEmail(string emailAdd);
        void Insert(RegisterViewModel model);
        IEnumerable<RegisterViewModel> GetAllBusinessAdmin();
    }
}
