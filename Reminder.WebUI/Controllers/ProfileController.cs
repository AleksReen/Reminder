using Reminder.Business.Providers;
using Reminder.Business.ReminderCache;
using Reminder.Common.Entity;
using Reminder.Common.Enums;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class ProfileController : Controller
    {
        private readonly string cacheKeyUserInf = "UserInfo";
        private IAppCache _cache;
        private IUserProvider _provider;

        public ProfileController(IUserProvider provider, IAppCache cache)
        {
            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null");
            }
            _provider = provider;
            _cache = cache;
        }
        // GET: Profile
        public ActionResult ProfilePage()
        {
            return View();
        }
        public ActionResult UserDetails()
        {
            return PartialView("_UserDetails", GetUserInfo());
        }

        public ActionResult UpdateProfile()
        { 
            return PartialView("_UpdateProfile", GetUserInfo());
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserReminder update)
        {
            if (ModelState.IsValid)
            {
                var result = _provider.UpdateProfile(update.UserId, update.Login, update.Email);
                if (result == ServerResponse.NoError)
                {
                    _cache.RemoveValue(cacheKeyUserInf);
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

        private UserReminder GetUserInfo()
        {
            var user = User as UserPrincipal;
            return _cache.GetValue(cacheKeyUserInf, () => _provider.GetEditeUser(user.UserId));
        }
    }
}