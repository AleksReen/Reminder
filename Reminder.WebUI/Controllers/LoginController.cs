﻿using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Models.ViewsModels;
using System.Web.Helpers;
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
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(ViewLogin loginInfo)
        {
            string passwordHash = null;

            if (ModelState.IsValid)
            {
               passwordHash = Crypto.SHA1(loginInfo.Password);
            }

            var result = _provider.Login(loginInfo.Login, passwordHash);

            if (result == ServerResponse.NoError)
            {
                return RedirectToAction("ReminderList", "Reminder");
            }

            
            if (result == ServerResponse.InvalidCredentials)
            {
                loginInfo.Message = "Invalid Credentials";
            }

            if (result == ServerResponse.EmptyCredentials)
            {
                loginInfo.Message = "Empty Credentials";
            }
            //TO DO
            return View("Login", loginInfo);
        }

        public ActionResult Logout()
        {
            _provider.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}