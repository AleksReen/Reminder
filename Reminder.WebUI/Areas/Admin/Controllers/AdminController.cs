using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Areas.Admin.Models;
using Reminder.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Reminder.WebUI.Areas.Admin.Controllers
{
    [Authorization(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IUserProvider _provider;

        public AdminController(IUserProvider provider)
        {
            _provider = provider;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return PartialView("_CreateUser");
        }

        [HttpPost]
        public ActionResult CreateUser(ViewCreateUser user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.SHA1(user.Password);
                var result = _provider.Registration(user.Login, user.Password, user.Email);
                if (result == ServerResponse.NoError)
                {
                    user.Message = user.Login;
                    ViewBag.Result = true;
                    return PartialView("_ResultCreateUser", user.Login);

                }
                if (result == ServerResponse.RegistrationFaild)
                {
                    user.Message = user.Login;
                    ViewBag.Result = false;
                    return PartialView("_ResultCreate", user.Login);
                }
            }

            return PartialView("_CreateUser");
        }

        public ActionResult ModifyUsers()
        {
            var userList = _provider.GetUsers().OrderBy(x => x.Login);
            
            return PartialView("_ModifyUsers", userList);
        }
    }
}