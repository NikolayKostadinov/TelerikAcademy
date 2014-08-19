using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Models.Identity
{
    public class RoleIntPk : IdentityRole<int, UserRoleIntPk>
    {
        public RoleIntPk()
        {
        }

        public RoleIntPk(string name)
        {
            Name = name;
        }
    }
}