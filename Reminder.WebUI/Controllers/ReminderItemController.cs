using Reminder.Business.Providers;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class ReminderItemController : Controller
    {
        private IReminderProvider _provider;

        public ReminderItemController(IReminderProvider provider)
        {
            _provider = provider;
        }
        
        public ActionResult GetDetails(int reminderId)
        {
            var model = _provider.GetReminders.Single(r => r.ReminderId == reminderId);

            return View(model);
        }
    }
}