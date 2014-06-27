using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileUpload.Models.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Helpers
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
            user.Email = userView.Email;
            user.PhoneNumber = userView.PhoneNumber;
            user.Roles.Clear();
            foreach (var role in userView.UserInRole)
            {
                user.Roles.Add(role);
            }
        }
    }
}