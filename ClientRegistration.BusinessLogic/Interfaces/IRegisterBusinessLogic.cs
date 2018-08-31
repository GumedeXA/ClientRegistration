using Wave28.Data.Entities;
using Wave28.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave28.BusinessLogic.Interfaces
{
    public interface IRegisterBusinessLogic
    {
        Register ConvertProject(RegisterViewModel model);
        RegisterViewModel GetById(int id);
        void Insert(RegisterViewModel model);
        IEnumerable<RegisterViewModel> GetAllRegisteredUsers();
    }
}
