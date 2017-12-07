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

                //var result = _providerCategory.AddCategory(category.CategoryName);
                //if (result == ServerResponse.NoError)
                //{
                //    category.Message = category.CategoryName;
                //    ViewBag.Result = true;
                //    return PartialView("_ResultCreate", category.CategoryName);
                //}
                //if (result == ServerResponse.DataBaseError)
                //{
                //    category.Message = category.CategoryName;
                //    ViewBag.Result = true;
                //    return PartialView("_ResultCreate", category.CategoryName);
                //}
            }

            return PartialView("_CreateUser");
        }
    }
}