using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using FileUpload.Data;
using FileUpload.Helpers;
using FileUpload.Models;
using FileUpload.Models.Identity;
using FileUpload.Models.ViewModels;
using FileUpload.Utility;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace FileUpload.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserAdministrationController : Controller
    {

        private readonly IUowData db;
        private IList<RoleIntPk> roles;
        
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ReadAllUsers([DataSourceRequest]DataSourceRequest request)
        {
            var users = db.Users.All().Select(AccountViewModel.ToAccountViewModel);
            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRolesByUser(int userId, [DataSourceRequest] DataSourceRequest request)
        {
            var userRoles = (db.Users.GetById(userId)).ToAccountViewModel(this.db).Roles;
            return Json(userRoles.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(AccountViewModel userAccount,[DataSourceRequest] DataSourceRequest request)
        {
            try
            {

                var persistentUser = db.Users.GetById(userAccount.Id);
                persistentUser.CopyPropFromAccountViewModel(userAccount, roles);
                db.Users.Update(persistentUser);
                db.SaveChanges();
                return Json(new[] { persistentUser.ToAccountViewModel(this.db) }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.GetType().ToString(), ex.Message);
                return Json(new[] { userAccount }.ToDataSourceResult(request, ModelState));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _AddNewUser(RegisterViewModel model, string urlToRedirect)
        {
            if (ModelState.IsValid)
            {
                var UserManager = HttpContext.GetOwinContext().GetUserManager<FileUpload.App_Start.ApplicationUserManager>();
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Redirect(urlToRedirect);
                }
                else
                {
                    AddErrors(result);
                }
            }
            ViewBag.Visible = true;
            return View("Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser([DataSourceRequest]DataSourceRequest request, AccountViewModel user)
        {

                if (user != null && ModelState.IsValid)
                {
                        if (user.Id == int.Parse(User.Identity.GetUserId()))
                        {
                            ModelState.AddModelError("", "You cannot delete current user.");
                        }
                        else
                        { 
                            db.Users.Delete(user.Id);
                            db.SaveChanges();
                        }
                }

                var users = db.Users.All().Select(AccountViewModel.ToAccountViewModel).ToList();

                return Json(users.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int userId, string redirect, string newPassword = "12345678") 
        {
            var userManager = this.HttpContext.GetOwinContext().GetUserManager<FileUpload.App_Start.ApplicationUserManager>();
            using (var tran = new TransactionScope())
            {
                userManager.RemovePassword(userId);
                userManager.AddPassword(userId, newPassword);
            }
            return Redirect(redirect);
        }
    }
}