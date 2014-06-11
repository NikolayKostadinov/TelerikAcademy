using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspMvcUserAdministration.Data;
using AspMvcUserAdministration.Models.ViewModels;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Kendo.Mvc.Extensions;
using AspMvcUserAdministration.Helpers;

namespace AspMvcUserAdministration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserAdministrationController : Controller
    {
        private IUowData db;
        private IList<IdentityRole> roles;
        public UserAdministrationController(IUowData db)
        {
            this.db = db;
            this.roles = db.Roles.All().ToList();
        }

        // GET: UserAdministration/Home
        public ActionResult Index()
        {
            ViewData["Roles"] = roles;
            return View();
        }

        public JsonResult ReadAllUsers([DataSourceRequest]DataSourceRequest request)
        {
            var users = db.Users.All().Select(AccountViewModel.ToAccountViewModel);
            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRolesByUser(string userId, [DataSourceRequest] DataSourceRequest request)
        {
            var userRoles = (db.Users.GetById(userId)).ToAccountViewModel().Roles;
            return Json(userRoles.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateUser([DataSourceRequest] DataSourceRequest request, AccountViewModel userAccount) 
        {
            try
            {
                var persistentUser = db.Users.GetById(userAccount.Id);
                persistentUser.CopyPropFromAccountViewModel(userAccount,roles);
                db.Users.Update(persistentUser);
                db.SaveChanges();
                return Json(new[] { persistentUser.ToAccountViewModel() }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.GetType().ToString(), ex.Message);
                return Json(new[] { userAccount }.ToDataSourceResult(request, ModelState));
            }
        }
    }
}