using Reminder.Business.Providers;
using Reminder.Common.Entity;
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
        
        //method returns a page with reminder details
        public ActionResult GetDetails(int reminderId)
        {
            var model = new ViewReminderFullInfo();

            model.Reminder = _provider.GetReminders.Single(r => r.ReminderId == reminderId); 
            model.ReminderInfo = _provider.GetReminderDescription(reminderId);
            model.Category = _provider.GetCategory.Single(x => x.CategoryId == model.Reminder.CategoryId);

            return View(model);
        }
        
        //method returns the value of the category for the reminder
        public ActionResult GetItemCategory(int id)
        {
            var category = _provider.GetCategory.Single(x => x.CategoryId == id);
            var categoryName = category.CategoryName;

            return PartialView("_GetItemCategory", categoryName);
        }
    }
}