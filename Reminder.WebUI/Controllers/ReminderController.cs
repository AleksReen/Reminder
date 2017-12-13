using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using Reminder.WebUI.Support;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class ReminderController : Controller
    {
        private readonly string defaultPath = "../Images/No-image-found.jpg";
        private IReminderProvider _providerReminder;
        private ICategoryProvider _providerCategory;

        public ReminderController(IReminderProvider provR, ICategoryProvider provC)
        {
            _providerReminder = provR;
            _providerCategory = provC;
        }

        public ActionResult Index()
        {
            var user = User as UserPrincipal;
            return View(new ViewReminderIndex { CurrentUser = user});
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

        private void SaveImage(HttpPostedFileBase Image, string name)
        {           
            if (Image != null)
            {
                Image.SaveAs(Server.MapPath("~/Images/" + name));  
            }
        }
    } 
}