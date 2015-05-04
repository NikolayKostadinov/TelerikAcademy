using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Вашата парола беше сменена успешно."
                : message == ManageMessageId.SetPasswordSuccess ? "Вашата парола беше зададена успешно."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Вашият доставчик за двъфакторна автентикация беше настроен успешно."
                : message == ManageMessageId.Error ? "Възникна грешка!"
                : message == ManageMessageId.AddPhoneSuccess ? "Вашият телефонен номер беше добавен успешно."
                : message == ManageMessageId.RemovePhoneSuccess ? "Вашият телефонен номер беше премахнат успешно."
                : "";
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "За възникнали проблеми и препоръки по отношение функционалността на системата се обръщайте към: ";

            return View();
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
    }
}