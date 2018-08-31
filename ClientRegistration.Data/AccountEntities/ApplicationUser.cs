using Microsoft.AspNet.Identity.EntityFramework;

namespace Wave28.Data.AccountEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
