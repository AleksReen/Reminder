using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.Enums;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using Reminder.WebUI.Support;
using System;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class ReminderController : Controller
    {
        private readonly string defaultPath = "/Images/No-image-found.jpg";
        private IReminderProvider _providerReminder;
        private ICategoryProvider _providerCategory;

        public ReminderController(IReminderProvider provR, ICategoryProvider provC)
        {
            if (provR == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provR");
            }
            _providerReminder = provR;

            if (provC == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provC");
            }
            _providerCategory = provC;
        }

        public ActionResult Index(string message, bool? resultAction)
        {
            var user = User as UserPrincipal;
            var model = new ViewReminderIndex { CurrentUser = user };

            if (!string.IsNullOrEmpty(message))
            {
                model.Message = message;
                model.Result = (bool)resultAction;
            }

            return View(model);
        }


        public ActionResult ReminderList(int? category)
        {
            Thread.Sleep(2000);
            var user = User as UserPrincipal;
            var reminders = _providerReminder.GetReminders(user.UserId)
                                                   .Where(c => category == null || c.CategoryId == category)
                                                   .OrderBy(c => c.Date);
            return PartialView("_ReminderList", reminders);
        }

        public ActionResult DeleteReminder(ViewDeleteReminder delRem)
        {
            Thread.Sleep(2000);
            return PartialView("_DeleteReminder", delRem);
        }

        
        public ActionResult СonfirmedDeleteReminder(int id)
        {
            var result = _providerReminder.DeleteReminder(id);
            if (result != default(string))
            {               
                if (result != defaultPath )
                {
                    var fullPath = Server.MapPath(result);

                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    
                }

                ViewBag.Result = true;
                return PartialView("_ResultDeleteReminder");
            }
            else
            {
                ViewBag.Result = false;
                return PartialView("_ResultDeleteReminder");
            }   
        }


        public ActionResult AddReminder()
        {
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return View("AddReminder");
        }

        [HttpPost]
        public ActionResult AddReminder(ViewNewReminder newReminder)
        {
            if (newReminder.Image != null && !ReminderSupport.ChechExtImg(newReminder.Image))
            {
                ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
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
                var imgName = ReminderSupport.GetNewImageName(newReminder.Image);
                var imagePath = ReminderSupport.GetImagePath(newReminder.Image, imgName);
                var actions = ReminderSupport.GetActions(newReminder.Actions);

                var result = _providerReminder.AddReminder(title, date, reminderTime, imagePath, categoryId, userId, actions, description);
                if (result == ServerResponse.NoError)
                {
                    if (newReminder.Image != null && !string.IsNullOrEmpty(imgName))
                    {
                        SaveImage(newReminder.Image, imgName);
                    }

                    return RedirectToAction("Index", new { message = "reminder was successfully created", resultAction = true });
                }
                if (result == ServerResponse.DataBaseError)
                {
                    return RedirectToAction("Index", new { message = "Some Errors", resultAction = true });
                }
            }

            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return View("AddReminder", newReminder);
        }

        public ActionResult EditeReminder(int reminderId)
        {
            var model = _providerReminder.GetReminderInfo(reminderId);
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
           
            return View(model);
        }

        [HttpPost]
        public ActionResult EditeReminder(ReminderInfo updateReminder, HttpPostedFileBase Img)
        {
            if (Img != null && !ReminderSupport.ChechExtImg(Img))
            {
                ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
                return View(updateReminder);
            }

            if (ModelState.IsValid)
            {
                var reminderId = updateReminder.Reminder.ReminderId;
                var title = updateReminder.Reminder.Title;
                var date = updateReminder.Reminder.Date;
                var reminderTime = updateReminder.Reminder.ReminderTime;
                var categoryId = updateReminder.Reminder.CategoryId;
                var description = updateReminder.Description;

                var imagePath = "";
                var imgName = "";
                if (Img != null)
                {
                    imgName = ReminderSupport.GetNewImageName(Img);
                    imagePath = ReminderSupport.GetImagePath(Img, imgName);
                }
                else
                {
                    imagePath = updateReminder.Reminder.Image;
                }

                var actions = ReminderSupport.GetActions(updateReminder.Actions);

                var result = _providerReminder.UpdateReminder(reminderId, title, date, reminderTime, imagePath, categoryId, actions, description);
                
                if (result == ServerResponse.NoError)
                {
                    if (imagePath != defaultPath && imagePath != updateReminder.Reminder.Image)
                    {
                        SaveImage(Img, imgName);

                        var fullPath = Server.MapPath(updateReminder.Reminder.Image);
                        
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }

                    return RedirectToAction("Index", new { message = "reminder was successfully updated", resultAction = true});
                }

                if (result == ServerResponse.DataBaseError)
                {                                       
                    return RedirectToAction("Index", new { message = "Some Errors", resultAction = false });
                }
            }

            return View(updateReminder);
        }


        private int GetCurrentUser()
        {
            var user = User as UserPrincipal;
            return user.UserId;
        }

        private void SaveImage(HttpPostedFileBase Image, string name)
        {           
            if (Image != null)
            {
                Image.SaveAs(Server.MapPath("~/Images/" + name));  
            }
        }
    } 
}