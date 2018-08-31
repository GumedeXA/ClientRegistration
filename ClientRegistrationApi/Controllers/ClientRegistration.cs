using Wave28.Data.AccountBusiness;
using Wave28.Data.AccountModels;
using Wave28.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security;

namespace Wave28Api.Controllers
{
    public class ClientRegistration : ApiController
    {
        #region Initialisation
       
        #endregion
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] 
            {
                "value1", "value2"
            };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        // POST: RegisterUsers/Create
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public async Task<IHttpActionResult> Post(RegisterViewModel registerView)
        {
            try
            {
                var roleBusiness = new RoleBusiness();
                var registerbusiness = new RegisterBusiness();
                var role = registerView.Role;

                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                //CODESC:Check if user Exist
                if (registerbusiness.FindUser(registerView.userName, AuthenticationManager))
                {
                    ModelState.AddModelError("", "User name already taken");
                    return Ok(registerView);
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
                    registerView.Role = "BusinessAdmin";
                    //_dbManagerBusiness.Insert(registerView);
                    registerbusiness.AddUserToRole(registerView.userName, role);
                }
             
            }
            catch (System.Exception e)
            {

                throw e.InnerException;
            }

            return Ok();
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