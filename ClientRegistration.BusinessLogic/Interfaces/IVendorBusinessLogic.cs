using ClientRegistration.Data.Entities;
using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;

namespace ClientRegistration.BusinessLogic.Interfaces
{
    public interface IVendorBusinessLogic
    {
      
        void Update(VendorViewModel model);
        void Insert(VendorViewModel model);
        VendorViewModel GetById(int VendorId);
        IEnumerable<VendorViewModel> GetAllVendorsByBusinessAdmin(string BusinessAdminId);
        void Delete(VendorViewModel model);
    }
}
