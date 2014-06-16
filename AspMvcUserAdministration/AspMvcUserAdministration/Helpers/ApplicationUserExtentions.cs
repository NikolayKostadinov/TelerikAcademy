using AspMvcUserAdministration.Models;
using AspMvcUserAdministration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspMvcUserAdministration.Helpers
{
    public static class ApplicationUserExtentions
    {
        public static AccountViewModel ToAccountViewModel(this ApplicationUser user) 
        {
            return new AccountViewModel()
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Email= user.Email,
                UserInRole = user.Roles,
                UserName = user.UserName
            };
        }

        public static void CopyPropFromAccountViewModel(this ApplicationUser user, AccountViewModel userView,IList<IdentityRole> roles) 
        {
            user.UserName = userView.UserName;
            user.PhoneNumber = userView.PhoneNumber;
            user.Roles.Clear();
            foreach (var role in userView.UserInRole)
            {
                user.Roles.Add(role);
            }
        }
    }
}