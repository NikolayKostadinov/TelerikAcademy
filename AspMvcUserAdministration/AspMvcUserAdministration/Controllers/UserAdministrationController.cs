using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspMvcUserAdministration.Data;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Kendo.Mvc.Extensions;

namespace AspMvcUserAdministration.Controllers
{
    [Authorize(Roles="Administrator")]
    public class UserAdministrationController : Controller
    {
        private IUowData db;

        public UserAdministrationController(IUowData db) 
        {
            this.db = db;
        }

        // GET: UserAdministration/Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadAllUsers([DataSourceRequest]DataSourceRequest request) 
        {
            var users = db.Users.All().ToList();
            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRolesByUser(string userId, [DataSourceRequest] DataSourceRequest request) 
        {
            var userRoles = db.Users.GetById(userId).Roles;
            var roles = new HashSet<IdentityRole>();
            foreach (var role in userRoles)
            {
                roles.Add(db.Roles.GetById(role.RoleId));
            }
            return Json(roles.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}