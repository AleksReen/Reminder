using Reminder.Business.Providers;
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

            //if (result == Business.Enums.LoginResult.NoError)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //var model = new LoginViewModel();
            //if (result == Business.Enums.LoginResult.EmptyCredentials)
            //{
            //    model.Message = "Check user name and password";
            //}
            //if (result == Business.Enums.LoginResult.InvalidCredentials)
            //{
            //    model.Message = "The user is not valid";
            //}
            //return View(model);
            return View();
        }
    }
}