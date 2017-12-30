using Reminder.Business.Providers;
using Reminder.Business.ReminderCache;
using Reminder.Common.Enums;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly string cacheKeyReminders = "Reminders";
        private IUserProvider _provider;
        private IAppCache _cache;


        public LoginController(IUserProvider provider, IAppCache cache)
        {
            if (provider == null || cache == null)
            {
                throw new ArgumentException("Parameter cannot be null");
            }
            _provider = provider;
            _cache = cache;
        }

        public ActionResult Login(string message, bool? resultAction)
        {
            var model = new ViewLogin();
            if (!string.IsNullOrEmpty(message))
            {
                model.Message = message;
                model.Result = (bool)resultAction;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(ViewLogin loginInfo)
        {
            if (ModelState.IsValid)
            {
               var passwordHash = Crypto.SHA1(loginInfo.Password);
               var result = _provider.Login(loginInfo.Login, passwordHash);

               if (result == ServerResponse.NoError)
               {
                    return RedirectToAction("Index", "Reminder");
               }

                if (result == ServerResponse.InvalidCredentials)
                {
                    loginInfo.Message = "Invalid Credentials";
                }

                if (result == ServerResponse.EmptyCredentials)
                {
                    loginInfo.Message = "Empty credentials, please use the registration";
                }
            }

            return View("Login", loginInfo);
        }

        public ActionResult Logout()
        {
            _provider.Logout();
            _cache.RemoveValue(cacheKeyReminders);

            return RedirectToAction("Index", "Home");
        }
    }
}