using System;
using System.Web.Http;
using System.Data.Entity.Validation;
using Microsoft.Owin.Security;
using System.Web;

using ClientRegistration.ViewModels.ViewModels;
using ClientRegistration.ViewModels.Validation_Messages;
using ClientRegistration.Data.AccountBusiness;
using ClientRegistration.Data.AccountModels;
using ClientRegistration.BusinessLogic.Logic;

namespace ClientRegistrationApi.Controllers.Api
{
    public class CustomerRegistrationController : ApiController
    {
        #region Initialisation
        CustomerRegisterBusinessLogic _dbCustomerlogic = new CustomerRegisterBusinessLogic();
       
        #endregion

        public CustomerRegistrationController()
        {
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
        [HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IHttpActionResult> Post([FromBody]RegisterViewModel registerView)
        {
            string lclRespondMsg = ValidationMessages.RespondMsg;
            try
            {
                var roleBusiness = new RoleBusiness();
                var registerbusiness = new RegisterBusiness();
                var role = registerView.Role;

                //CODESC:Check if user Exist
                if (registerbusiness.FindUser(registerView.userName, AuthenticationManager))
                {
                    ModelState.AddModelError("", "User name already taken");
                    return Ok(ValidationMessages.UserNameTaken);
                }
                //CODESC:Check if user does'nt Exist else create a role for him/her
                if (!roleBusiness.RoleExists(role))
                {
                    roleBusiness.CreateRole(role);
                }
                //CODESC:Than check if user exist
                var result = await registerbusiness.RegisterUser(new RegisterModel
                {
                    UserName = registerView.userName,
                    Password = registerView.Password
                }, AuthenticationManager);

                //CODESC:If The Result Passes Register Admin and Vendor
                if (result)
                {
                    try
                    {
                        _dbCustomerlogic.Insert(registerView);
                        registerbusiness.AddUserToRole(registerView.userName, role);
                        lclRespondMsg = "Saved Successfully";
                    }
                    catch (DbEntityValidationException e)
                    {
                        throw e.InnerException;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return Ok(lclRespondMsg);
        }
    }
}
