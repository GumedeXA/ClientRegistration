using ClientRegistration.Data.AccountBusiness;
using ClientRegistration.Data.AccountModels;
using ClientRegistration.ViewModels.ViewModels;
using ClientRegistration.ViewModels.Validation_Messages;

using ClientRegistration.BusinessLogic.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace ClientRegistration.Controllers.Api
{
    [RoutePrefix("api/BusinessAdminRegistration")]
    public class BusinessAdminRegistrationController : ApiController
    {
        #region Initialisation
        BusAdminBusinessLogic _dbBusinessAdmin = new BusAdminBusinessLogic();
        VendorBusinessLogic _dbVendor = new VendorBusinessLogic();
        #endregion

        public BusinessAdminRegistrationController()
        {}
        // GET api/<controller>
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            IList<RegisterViewModel> businessAdmin = null;
            try
            {
                businessAdmin=_dbBusinessAdmin.GetAllBusinessAdmin().ToList();

                if (businessAdmin.Count==0)
                {
                    return NotFound();
                }
                return Ok(businessAdmin);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        // GET api/<controller>/5
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            RegisterViewModel businessAdmin = null;
            try
            {
                businessAdmin = _dbBusinessAdmin.GetBusinessAdminById(id);
                return Ok(businessAdmin);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        // POST: RegisterUsers/Create
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Post([FromBody]RegisterViewModel registerView)
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
                        _dbVendor.Insert(registerView);
                        _dbBusinessAdmin.Insert(registerView);
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
                throw  ex.InnerException;
            }
            return Ok(lclRespondMsg);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}