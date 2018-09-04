using ClientRegistration.Data.AccountEntities;
using ClientRegistration.Data.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ClientRegistration.Data.AccountBusiness
{
    public class RoleBusiness
    {
        private RoleManager<ApplicationRole> RoleManager { get; set; }

        public RoleBusiness()
        {
            RoleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new DataContext()));
        }

        public bool RoleExists(string name)
        {
            return RoleManager.RoleExists(name);
        }

        public bool CreateRole(string name)
        {
            var idResult = RoleManager.Create(new ApplicationRole(name));
            return idResult.Succeeded;
        }

    }
}
