using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;
using System;
using WebChat.Models;

namespace WebChat.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser" /> class.
        /// </summary>
        public ApplicationUser() : base()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }    
}