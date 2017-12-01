using Reminder.Business.Providers;
using Reminder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private ILoginProvider _provider;

        public LoginController(ILoginProvider prov)
        {
            _provider = prov;
        }
        // GET: Login
        public ActionResult Login()
        {
            return PartialView("_Login");
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {

            var result = _provider.Login(login, password);

            if (result == LoginResult.NoError)
            {
                return RedirectToAction("ReminderList", "Reminder");
            }
            //TO DO
            return PartialView("_Login");
        }
    }
}