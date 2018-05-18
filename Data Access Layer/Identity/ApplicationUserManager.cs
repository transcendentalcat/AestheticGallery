using Data_Access_Layer.Entities;
using Microsoft.AspNet.Identity;

namespace Data_Access_Layer.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
