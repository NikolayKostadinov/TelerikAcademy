using FileUpload.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Data
{
    public class RoleStoreIntPk : RoleStore<RoleIntPk, int, UserRoleIntPk>
    {
        public RoleStoreIntPk(ApplicationDbContext context) : base(context)
        {
        }
    }
}