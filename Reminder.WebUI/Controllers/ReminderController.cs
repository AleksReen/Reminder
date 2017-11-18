using Reminder.Business.Providers;
using Reminder.Domain.Entity;
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
        public ActionResult Index()
        {
            var pr = _provider.GetCategory();
            var c = _provider.GetReminders();

             return View();
        }
    }
}