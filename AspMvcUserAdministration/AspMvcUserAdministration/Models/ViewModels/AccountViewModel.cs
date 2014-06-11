using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AspMvcUserAdministration.Data;
using AspMvcUserAdministration.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspMvcUserAdministration.Models.ViewModels
{
    public class AccountViewModel
    {
        private IUowData db;
        private HashSet<IdentityRole> roles = new HashSet<IdentityRole>();

        public AccountViewModel()
        {
            this.db = new UowData();
        }

        //Dependanci injector constructor
        public AccountViewModel(IUowData db) 
        {
            this.db = db;
        }
       
        public static Expression<Func<ApplicationUser, AccountViewModel>> ToAccountViewModel
        {
            get
            {
                return a => new AccountViewModel()
                {
                    Id = a.Id,
                    UserName = a.UserName,
                    Email = a.Email,
                    PhoneNumber = a.PhoneNumber,
                    UserInRole = a.Roles
                };
            }
        }

        public IEnumerable<int> SelectedRoles { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<IdentityUserRole> UserInRole { get; set; }

        [UIHint("RoleEditor")]
        public HashSet<IdentityRole> Roles
        {
            get
            {
                HashSet<IdentityRole> userInRoles = new HashSet<IdentityRole>();
                if (UserInRole == null)
                { 
                    return null; 
                }
                foreach (var role in this.UserInRole)
                {
                    userInRoles.Add(db.Roles.GetById(role.RoleId));
                }

                this.roles = userInRoles;
                return this.roles;
            }
            set 
            {
                if (value == null)
                {
                    this.roles = null;
                    return;
                }
                else
                {
                    this.roles.Clear();
                    this.UserInRole.Clear();

                    foreach (var role in value) 
                    {
                        this.roles.Add(role);
                        this.UserInRole.Add(new IdentityUserRole() { UserId = this.Id, RoleId = role.Id });
                    }
                }
            }
        }
    }
}