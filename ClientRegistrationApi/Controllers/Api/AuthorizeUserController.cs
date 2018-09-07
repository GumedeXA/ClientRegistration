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
            string lclRespondMsg = ValidationMessages.RespondMsg;
            try
            {
                var loginbusiness = new LoginBusiness();
                RegisterBusiness regbusines = new RegisterBusiness();
                //Pass model to login
                var result = await loginbusiness.LogUserIn(lgmodel, AuthenticationManager);
                if (result)
                {
                    lclRespondMsg = "Login Successfully";
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
