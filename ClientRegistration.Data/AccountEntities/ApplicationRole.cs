using Microsoft.AspNet.Identity.EntityFramework;

namespace Wave28.Data.AccountEntities
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
