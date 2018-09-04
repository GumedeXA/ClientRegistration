using Microsoft.AspNet.Identity.EntityFramework;

namespace ClientRegistration.Data.AccountEntities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        { }

        public ApplicationRole(string roleName)
            : base(roleName)
        {
        }
    }
}
