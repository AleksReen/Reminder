using Reminder.Business.Providers;
using Reminder.Domain.Entity;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    //the controller processes a separate reminder
    public class ReminderItemController : Controller
    {
        private IReminderProvider _provider;

        public ReminderItemController(IReminderProvider provider)
        {
            _provider = provider;
        }
        //method returns a page with  reminder
        public ActionResult GetReminderItem(MyReminder reminder)
        {
            return PartialView("_GetReminderItem", reminder);
        }
        
        //method returns a page with reminder details
        public ActionResult GetDetails(int reminderId)
        {
            var model = _provider.GetReminders.Single(r => r.ReminderId == reminderId);

            return View(model);
        }
        
        //method returns the value of the category for the reminder
        public ActionResult GetItemCategory(int id)
        {
            var category = _provider.GetCategory.Single(x => x.CategoryId == id);
            string categoryName = category.Name;

            return PartialView("_GetItemCategory", categoryName);
        }
    }
}