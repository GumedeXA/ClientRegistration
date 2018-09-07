using ClientRegistration.BusinessLogic.Interfaces;
using ClientRegistration.Data.Entities;
using ClientRegistration.Repository.Repository;
using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ClientRegistration.BusinessLogic.Logic
{
    public class CustomerRegisterBusinessLogic : ICustomerRegisterBusinessLogic
    {
        private static Customer ConvertToRegister(CustomerViewModel model)
        {
            var registercust = new Customer
            {
                Role = model.Role,
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
            return registercust;
        }

        public CustomerViewModel GetById(int id)
        {
            using (var db = new CustomerRegisterRepository())
            {
                var regUser = db.GetAll().ToList().Find(d => (d.CustId == id));

                var regVmodel = new CustomerViewModel();
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

        public void Insert(CustomerViewModel model)
        {
            using (var db = new CustomerRegisterRepository())
            {
                db.Insert(ConvertToRegister(model));

            }
        }

        public IEnumerable<CustomerViewModel> GetAllRegisteredUsers()
        {
            using (var db = new CustomerRegisterRepository())
            {
                return db.GetAll().Select(model => new CustomerViewModel
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
