using ClientRegistration.Data.Entities;
using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;

namespace ClientRegistration.BusinessLogic.Interfaces
{
    public interface IVendorBusinessLogic
    {
      
        void Update(RegisterViewModel model);
        void Insert(RegisterViewModel model);
        VendorViewModel GetById(int VendorId);
        IEnumerable<VendorViewModel> GetAllVendorsByBusinessAdmin(string BusinessAdminId);
        void Delete(RegisterViewModel model);
    }
}
