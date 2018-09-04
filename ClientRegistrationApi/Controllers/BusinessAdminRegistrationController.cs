using ClientRegistration.Data.AccountBusiness;
using ClientRegistration.Data.AccountModels;
using ClientRegistration.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security;
using ClientRegistration.BusinessLogic.Logic;
using System;
using System.Linq;
using System.Web.Http.Description;
using System.Net.Http;
using System.Net;

namespace ClientRegistration.Controllers
{
    [RoutePrefix("api/BusinessAdminRegistration")]
    public class BusinessAdminRegistrationController : ApiController
    {
        #region Initialisation
        BusAdminBusinessLogic _dbBusinessAdmin = new BusAdminBusinessLogic();
        #endregion

        public BusinessAdminRegistrationController()
        {}
        // GET api/<controller>
        [HttpGet]
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
        [HttpGet]
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

        [HttpPost]
        [ResponseType(typeof(RegisterViewModel))]
        public async Task<HttpResponseMessage> Post([FromBody]RegisterViewModel registerView)
        {
            try
            {
                var roleBusiness = new RoleBusiness();
                var registerbusiness = new RegisterBusiness();
                var role = registerView.Role;

                //CODESC:Check if user Exist
                if (registerbusiness.FindUser(registerView.userName, AuthenticationManager))
                {
                    ModelState.AddModelError("", "User name already taken");
                    return Request.CreateResponse(registerView);
                }
                //CODESC:Check if user does'nt Exist else create a role for him/her
                if (!roleBusiness.RoleExists(role))
                {
                    roleBusiness.CreateRole(role);
                }
                //CODESC:Than Register the user
                var result = await registerbusiness.RegisterUser(new RegisterModel
                {
                    UserName = registerView.Email,
                    Password = registerView.Password
                }, AuthenticationManager);

                //CODESC:If The Result Passes Register User
                if (result)
                {
                    _dbBusinessAdmin.Insert(registerView);
                    registerbusiness.AddUserToRole(registerView.userName, role);
                }
             
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return Request.CreateResponse(registerView);
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