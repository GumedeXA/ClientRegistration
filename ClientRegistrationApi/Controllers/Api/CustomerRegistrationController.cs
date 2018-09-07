using System;
using System.Web.Http;
using System.Data.Entity.Validation;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using ClientRegistration.ViewModels.ViewModels;
using ClientRegistration.ViewModels.Validation_Messages;
using ClientRegistration.Data.AccountBusiness;
using ClientRegistration.Data.AccountModels;
using ClientRegistration.BusinessLogic.Logic;

namespace ClientRegistrationApi.Controllers.Api
{
    [RoutePrefix("api/CustomerRegistration")]
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
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Post([FromBody]CustomerViewModel customerView)
        {
            string lclRespondMsg = ValidationMessages.RespondMsg;
            try
            {
                var roleBusiness = new RoleBusiness();
                var registerbusiness = new RegisterBusiness();
                var role = customerView.Role;

                //CODESC:Check if user Exist
                if (registerbusiness.FindUser(customerView.userName, AuthenticationManager))
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
                    UserName = customerView.userName,
                    Password = customerView.Password
                }, AuthenticationManager);

                //CODESC:If The Result Passes Register Admin and Vendor
                if (result)
                {
                    try
                    {
                        _dbCustomerlogic.Insert(customerView);
                        registerbusiness.AddUserToRole(customerView.userName, role);
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
