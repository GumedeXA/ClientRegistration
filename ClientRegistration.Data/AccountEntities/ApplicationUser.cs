using Microsoft.AspNet.Identity.EntityFramework;

namespace ClientRegistration.Data.AccountEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
