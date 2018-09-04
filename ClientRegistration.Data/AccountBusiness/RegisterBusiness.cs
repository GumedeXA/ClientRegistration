using ClientRegistration.Data.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using ClientRegistration.Data.AccountEntities;
using ClientRegistration.Data.AccountModels;

namespace ClientRegistration.Data.AccountBusiness
{
    public class RegisterBusiness
    {
        public UserManager<ApplicationUser> UserManager { get; set; }

        public RegisterBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
            {
                AllowOnlyAlphanumericUserNames = false,
            };
        }

        public bool FindUser(string userName, IAuthenticationManager authenticationManager)
        {
            var user = UserManager.FindByName(userName);
            return user != null;
        }


        public async Task<bool> RegisterUser(RegisterModel objRegisterModel, IAuthenticationManager authenticationManager)
        {
            var newuser = new ApplicationUser()
            {
                Id = objRegisterModel.UserName,
                UserName = objRegisterModel.UserName,
                Email = objRegisterModel.UserName,
                PasswordHash = UserManager.PasswordHasher.HashPassword(objRegisterModel.Password)
            };

            var result = await UserManager.CreateAsync(
               newuser, objRegisterModel.Password);

            if (!result.Succeeded) return false;
            return true;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
        public bool AddUserToRole(string user, string role)
        {
            var result = UserManager.AddToRole(user, role);

            return result.Succeeded;
        }


        public bool UserInRole(string username, string role)
        {
            return UserManager.IsInRole(username, role);
        }

    }
}
