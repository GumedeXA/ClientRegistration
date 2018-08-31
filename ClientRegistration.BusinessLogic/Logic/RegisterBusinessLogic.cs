using Wave28.BusinessLogic.Interfaces;
using Wave28.Data.Entities;
using Wave28.Repository.Repository;
using Wave28.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Wave28.BusinessLogic.Logic
{
    public class RegisterBusinessLogic : IRegisterBusinessLogic
    {
        private static Register ConvertProject(RegisterViewModel model)
        {
            var register = new Register
            {

                Email = model.Email,
                userName = model.userName,
                fullNames = model.fullNames,
                phoneNumber = model.phoneNumber,
                PostalAddress = model.PostalAddress,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Role = model.Role

            };
            return register;
        }

        Register IRegisterBusinessLogic.ConvertProject(RegisterViewModel model)
        {
            return ConvertProject(model);
        }

        public RegisterViewModel GetById(int id)
        {
            using (var db = new RegisterRepositoryImplememantation())
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

                }
                return regVmodel;

            }
        }

        public void Insert(RegisterViewModel model)
        {
            using (var db = new RegisterRepositoryImplememantation())
            {
                db.Insert(ConvertProject(model));

            }
        }

        public IEnumerable<RegisterViewModel> GetAllRegisteredUsers()
        {
            using (var db = new RegisterRepositoryImplememantation())
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
                    Role = model.Role

                });
            }
        }
    }
}
