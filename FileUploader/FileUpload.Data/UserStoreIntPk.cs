using FileUpload.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public class UserStoreIntPk : UserStore<ApplicationUser, RoleIntPk, int,
        UserLoginIntPk, UserRoleIntPk, UserClaimIntPk>
    {
        public UserStoreIntPk(ApplicationDbContext context) : base(context)
        {
        }
    }
}