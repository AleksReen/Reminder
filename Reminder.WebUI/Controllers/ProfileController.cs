using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.Enums;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Threading;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class ProfileController : Controller
    {
        private IUserProvider _provider;

        public ProfileController(IUserProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provider");
            }
            _provider = provider;
        }
        // GET: Profile
        public ActionResult ProfilePage()
        {
            return View();
        }
        public ActionResult UserDetails()
        {
            var user = User as UserPrincipal;
            var profile = _provider.GetEditeUser(user.UserId);

            return PartialView("_UserDetails", profile);
        }

        public ActionResult UpdateProfile()
        {
            var user = User as UserPrincipal;
            var profile = _provider.GetEditeUser(user.UserId);
            return PartialView("_UpdateProfile", profile);
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserReminder update)
        {
            if (ModelState.IsValid)
            {
                var result = _provider.UpdateProfile(update.UserId, update.Login, update.Email);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
                    return PartialView("_ResultUpdateProfile", update.Login);

                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultUpdateProfile", update.Login);
                }
            }
            return PartialView("_UpdateProfile", update);
        }
       
        public ActionResult SetPassword()
        {
            return PartialView("_SetPassword");
        }

        [HttpPost]
        public ActionResult SetPassword(ViewUserPassword userPassword)
        {
            if (ModelState.IsValid)
            {
                var password = Crypto.SHA1(userPassword.Password);
                var user = User as UserPrincipal;
                var result = _provider.UpdatePassword(user.UserId, password);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
                    return PartialView("_ResultUpdateProfile");

                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultUpdateProfile");
                }
            }
            return PartialView("_SetPassword");
        }
    }
}