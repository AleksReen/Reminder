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
        private IBusinessProvider _provider;
        public ReminderController(IBusinessProvider prov)
        {
            _provider = prov;
        }
        // GET: Reminder
        public ActionResult Index()
        {
            var pr = _provider;

             return View();
        }
    }
}