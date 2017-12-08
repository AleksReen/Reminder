using Reminder.Business.Providers;
using Reminder.Common.Entity;
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
                    ViewBag.Result = true;
                    return PartialView("_ResultCreateUser", user.Login);

                }
                if (result == ServerResponse.RegistrationFaild)
                {
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

        public ActionResult EditeUser(int id)
        {
            var user = _provider.GetEditeUser(id);
            ViewBag.Roles = _provider.GetRoles();

            return PartialView("_EditeUser", user);
        }

        [HttpPost]
        public ActionResult EditeUser(UserReminder updateUser)
        {
            if (ModelState.IsValid)
            {
                var result = _provider.UpdateUser(updateUser.UserId, updateUser.Login, updateUser.Email, updateUser.UserRole.RoleId);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
                    return PartialView("_ResultUpdateUser", updateUser.Login);

                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultUpdateUser", updateUser.Login);
                }
            }
            ViewBag.Roles = _provider.GetRoles();
            return PartialView("_EditeUser", updateUser);
        }

        public ActionResult DeleteUser(UserReminder user)
        {          
            return PartialView("_DeleteUser", user);
        }

        public ActionResult СonfirmedDeleteUser(int id)
        {
            var result = _provider.DeleteUser(id);
            if (result == ServerResponse.NoError)
            {
                ViewBag.Result = true;
                return PartialView("_ResultDeleteUser");
            }
            else
            {
                ViewBag.Result = false;
                return PartialView("_ResultUpdateUser");
            }
        }
    }
}