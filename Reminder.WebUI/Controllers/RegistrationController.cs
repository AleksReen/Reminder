using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class RegistrationController : Controller
    {
        private IUserProvider _provider;

        public RegistrationController(IUserProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provider");
            }
            _provider = provider;
        }
        public ActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Registration(ViewRegistration regForm)
        {
            if (ModelState.IsValid)
            {
                regForm.Password = Crypto.SHA1(regForm.Password);
                var result = _provider.Registration(regForm.Login,regForm.Password,regForm.Email);
                if (result == ServerResponse.NoError)
                {
                    var response = new { message = "Registration was successful, use your login and password to log in", resultAction = true };
                    return RedirectToAction("Login", "Login", response);
                }
                if (result == ServerResponse.RegistrationFaild)
                {
                    regForm.Message = "Registration Faild";
                }
            }

            return View(regForm);
        }
    }
}