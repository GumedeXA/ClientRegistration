using ClientRegistrationApi.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(StartUp))]
namespace ClientRegistrationApi.App_Start
{

    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/Create")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            // app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}