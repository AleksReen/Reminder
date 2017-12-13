using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Models.ViewsModels;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IUserProvider _provider;

        public LoginController(IUserProvider prov)
        {
            _provider = prov;
        }

        public ActionResult Login()
        {
            return View("Login");
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

            return RedirectToAction("Index", "Home");
        }
    }
}