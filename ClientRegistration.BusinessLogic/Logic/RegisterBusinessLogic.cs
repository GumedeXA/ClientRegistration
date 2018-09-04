using ClientRegistration.BusinessLogic.Interfaces;
using ClientRegistration.Data.Entities;
using ClientRegistration.Repository.Repository;
using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Wave28.BusinessLogic.Logic
{
    public class RegisterBusinessLogic : IRegisterBusinessLogic
    {
        private static Register ConvertToRegister(RegisterViewModel model)
        {
            var register = new Register
            {
                Role = model.Role,
                RegisterId=model.RegisterId,
                IdNumber=model.IdNumber,
                Email = model.Email,
                userName = model.userName,
                fullNames = model.fullNames,
                phoneNumber = model.phoneNumber,
                PostalAddress = model.PostalAddress,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                RegistrationDate = model.RegistrationDate,
                
                
            };
            return register;
        }

        public RegisterViewModel GetById(int id)
        {
            using (var db = new RegisterRepository())
            {
                var regUser = db.GetAll().ToList().Find(d => (d.RegisterId == id));

                var regVmodel = new RegisterViewModel();
                {

                    regVmodel.Email = regUser.Email;
                    regVmodel.userName = regUser.userName;
                    regVmodel.fullNames = regUser.fullNames;
                    regVmodel.phoneNumber = regUser.phoneNumber;
                    regVmodel.PostalAddress = regUser.PostalAddress;
                    regVmodel.Password = regUser.Password;
                    regVmodel.ConfirmPassword = regUser.ConfirmPassword;
                    regVmodel.Role = regUser.Role;
                    regVmodel.RegistrationDate = regUser.RegistrationDate;

                }
                return regVmodel;

            }
        }

        public void Insert(RegisterViewModel model)
        {
            using (var db = new RegisterRepository())
            {
                db.Insert(ConvertToRegister(model));

            }
        }

        public IEnumerable<RegisterViewModel> GetAllRegisteredUsers()
        {
            using (var db = new RegisterRepository())
            {
                return db.GetAll().Select(model => new RegisterViewModel
                {
                    Email = model.Email,
                    userName = model.userName,
                    fullNames = model.fullNames,
                    phoneNumber = model.phoneNumber,
                    PostalAddress=model.PostalAddress,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    RegistrationDate=model.RegistrationDate,
                    Role = model.Role

                });
            }
        }
    }
}
