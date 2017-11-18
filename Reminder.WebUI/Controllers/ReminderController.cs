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
    public class ReminderController : Controller
    {
        private IReminderProvider _provider;
        public ReminderController(IReminderProvider prov)
        {
            _provider = prov;
        }
        // GET: Reminder
        public ActionResult ReminderList(string category)
        {
            ViewReminderList model = new ViewReminderList();

            model.Reminders = _provider.GetReminders
                                                    .Where(c => category == null || c.CategoryId == category)
                                                    .OrderBy(c => c.ReminderId);
                                                    

            return View(model);
        }
    }
}