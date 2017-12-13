using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.Enums;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

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

        public ActionResult DeleteReminder(ViewDeleteReminder delRem)
        {

            return PartialView("_DeleteReminder", delRem);
        }

        
        public ActionResult СonfirmedDeleteReminder(int id)
        {

            return RedirectToAction("ReminderList");
        }


        public ActionResult AddReminder()
        {
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return View("AddReminder");
        }

        [HttpPost]
        public ActionResult AddReminder(ViewNewReminder newReminder)
        {
            if (newReminder.Image != null && !ChechExtImg(newReminder.Image))
            {
                return View("AddReminder", newReminder);
            }

            if (ModelState.IsValid)
            {

                var userId = GetCurrentUser();
                var title = newReminder.Reminder.Title;
                var date = newReminder.Reminder.Date;
                var reminderTime = newReminder.Reminder.ReminderTime;
                var categoryId = newReminder.CategoryId;
                var description = newReminder.Description;
                var imgName = GetNewImageName(newReminder.Image);
                var imagePath = GetImagePath(newReminder.Image, imgName);

                var actions = GetActions(newReminder.Actions);

                var result = _providerReminder.AddReminder(title, date, reminderTime, imagePath, categoryId, userId, actions, description);
                if (result == ServerResponse.NoError)
                {
                    if (newReminder.Image != null && !string.IsNullOrEmpty(imgName))
                    {
                        SaveImage(newReminder.Image, imgName);
                    }
                    
                    ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
                    ViewBag.Result = true;
                    return View("AddReminder", new ViewNewReminder() { Message = "reminder was successfully created" });
                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
                    ViewBag.Result = false;
                    newReminder.Message = "Some Errors";
                    return View("AddReminder", newReminder);
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
            if (Image != null)
            {
                var ex = Path.GetExtension(Image.FileName);
                var name = Path.GetFileNameWithoutExtension(Image.FileName);
                var nameRandom = new Random().Next(1, 1000000).ToString();

                return name + nameRandom + ex;
            }
            return null;
        }
        private string GetActions(IEnumerable<string> list)
        {
            var filter = list.Where(x => !string.IsNullOrEmpty(x)); 

            if (filter.Any())
            {
                var actions = ToXmlString(filter.ToArray());
                return actions;
            }
            return null;
        }

        private string ToXmlString(string[] list)
        {
            XmlSerializer xs = new XmlSerializer(typeof(string[]));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, list);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    } 
}