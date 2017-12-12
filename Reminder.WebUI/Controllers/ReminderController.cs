using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class ReminderController : Controller
    {
        private IReminderProvider _providerReminder;
        private ICategoryProvider _providerCategory;

        public ReminderController(IReminderProvider provR, ICategoryProvider provC)
        {
            _providerReminder = provR;
            _providerCategory = provC;
        }

        public ActionResult ReminderList(int? category)
        {
            var model = new ViewReminderList();
            var user = User as UserPrincipal;
            var reminders = _providerReminder.GetReminders(user.UserId)
                                                   .Where(c => category == null || c.CategoryId == category)
                                                   .OrderBy(c => c.Date);
            model.CurrentUser = user;
            model.Reminders = reminders;

            return View(model);
        }

        public ActionResult AddReminder()
        {
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return View("AddReminder");
        }

        [HttpPost]
        public ActionResult AddReminder(ViewNewReminder newReminder)
        {
            if (!ChechExtImg(newReminder.Image))
            {
                return View("AddReminder", newReminder);
            }

            if (ModelState.IsValid)
            {
                var userId = GetCurrentUser();
                var imgName = GetNewImageName(newReminder.Image);
                var imagePath = GetImagePath(newReminder.Image, imgName);
                var action = GetFilterActions(newReminder.Actions);


                var result = ServerResponse.NoError;
                //var result = _provider.UpdateUser(updateUser.UserId, updateUser.Login, updateUser.Email, updateUser.UserRole.RoleId);
                if (result == ServerResponse.NoError)
                {
                    SaveImage(newReminder.Image, imgName);

                }
                if (result == ServerResponse.DataBaseError)
                {
                    //ViewBag.Result = false;
                    //return PartialView("_ResultUpdateUser", updateUser.Login);
                }
            }


            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return View("AddReminder", newReminder);
        }

        private int GetCurrentUser()
        {
            var user = User as UserPrincipal;
            return user.UserId;
        }

        private string GetImagePath(HttpPostedFileBase Image, string name)
        {
            var imagePath = "";

            if (Image != null)
            {
                return imagePath = Path.Combine("../Images/" + name);
            }
             
            return imagePath = "../Images/No-image-found.jpg";
        }

        private void SaveImage(HttpPostedFileBase Image, string name)
        {           
            if (Image != null)
            {
                Image.SaveAs(Server.MapPath("~/Images/" + name));  
            }
        }

        private bool ChechExtImg(HttpPostedFileBase Image)
        {
            var exFormat = new string[] { ".jpg", ".jpeg", ".gif", ".png" };
            var ex = Path.GetExtension(Image.FileName);

            if (exFormat.Contains(ex))
            {
                return true;
            }
            return false;
        }

        private string GetNewImageName(HttpPostedFileBase Image)
        {
            var ex = Path.GetExtension(Image.FileName);
            var name = Path.GetFileNameWithoutExtension(Image.FileName);
            var nameRandom = new Random().Next(1, 1000000).ToString();

            return name + nameRandom + ex;
        }
        private string [] GetFilterActions(IEnumerable<string> list)
        {
            var filterList = list.Where(x => !string.IsNullOrEmpty(x)); 

            if (!list.Any())
            {
                list = null;
            }
            return filterList.ToArray<string>();
        }
    } 
}