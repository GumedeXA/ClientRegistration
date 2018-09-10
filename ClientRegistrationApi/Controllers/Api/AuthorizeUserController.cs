using System.Web.Http;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using ClientRegistration.Data.AccountModels;
using ClientRegistration.Data.AccountBusiness;
using ClientRegistration.ViewModels.Validation_Messages;

namespace ClientRegistrationApi.Controllers.Api
{
    [RoutePrefix("api/AuthorizeUser")]
    public class AuthorizeUserController : ApiController
    {
        public AuthorizeUserController()
        { }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LogInUser")]
        public async Task<IHttpActionResult> Post([FromBody]LoginModel lgmodel)
        {
            string lclRespondMsg = "";
            try
            {
                var loginbusiness = new LoginBusiness();
                RegisterBusiness regbusines = new RegisterBusiness();
                //Pass model to login
                var result = await loginbusiness.LogUserIn(lgmodel, AuthenticationManager);
                if (result)
                {
                    if (regbusines.UserInRole(lgmodel.UserName, "BusinessAdmin"))
                    {
                        lclRespondMsg = "BusinessAdmin";
                    }
                    else if (regbusines.UserInRole(lgmodel.UserName, "Customer"))
                    {
                        lclRespondMsg = "Customer";
                    }
                    else
                    {
                        lclRespondMsg = "Unknown User";
                    }
                }
            }
            catch (System.Exception ex)
            {

                throw ex.InnerException;
            }

            return Ok(lclRespondMsg);
        }
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LogOff")]
        public IHttpActionResult Post()
        {
            string lclRespondMsg = ValidationMessages.RespondMsg;
            AuthenticationManager.SignOut();
            lclRespondMsg = "LoggedOut Successfully";
            return Ok(lclRespondMsg);
        }

    }
}
