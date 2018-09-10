using ClientRegistration.BusinessLogic.Interfaces;
using System.Collections.Generic;
using ClientRegistration.Data.Entities;
using ClientRegistration.ViewModels.ViewModels;
using ClientRegistration.Repository.Repository;
using System.Linq;

namespace ClientRegistration.BusinessLogic.Logic
{
    public class BusAdminBusinessLogic : IBusAdminBusinessLogic
    {
       
        public static BusinessAdmin ConvertToBusinessModel (RegisterViewModel model)
        {
            var busAdmin = new BusinessAdmin
            {
                IdNumber = model.IdNumber,
                userName = model.userName,
                Email = model.Email,
                fullNames = model.fullNames,
                phoneNumber = model.phoneNumber,
                PostalAddress = model.PostalAddress,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Role = model.Role,
                RegistrationDate=model.RegistrationDate,
                vendorId=model.Id,
                BusAdminId=model.Id
            };
            return busAdmin;
        }

        public IEnumerable<RegisterViewModel> GetAllBusinessAdmin()
        {
            using (var db = new BusinessAdminRepository())
            {
                return db.GetAll().Select(model => new RegisterViewModel
                {
                    IdNumber = model.IdNumber,
                    Id=model.BusAdminId,
                    Email = model.Email,
                    fullNames = model.fullNames,
                    phoneNumber = model.phoneNumber,
                    PostalAddress = model.PostalAddress,
                    Password = model.Password,
                    Role = model.Role,
                    ConfirmPassword = model.ConfirmPassword,
                    RegistrationDate=model.RegistrationDate,
                    userName=model.userName,
                 
                });
            }
        }

        public RegisterViewModel GetBusinessAdminByEmail(string emailAdd)
        {
            return GetAllBusinessAdmin().FirstOrDefault(x => x.Email.Equals(emailAdd));
        }

        public RegisterViewModel GetBusinessAdminById(int businessAdminId)
        {
            return GetAllBusinessAdmin().FirstOrDefault(x => x.Id.Equals(businessAdminId));
        }
        public void Insert(RegisterViewModel model)
        {
            using (var db = new BusinessAdminRepository())
            {
                db.Insert(ConvertToBusinessModel(model));
            }
        }
    }
}
