using Reminder.Business;
using Reminder.Domain.FakeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class ReminderController : Controller
    {

        public ReminderController()
        {
           
        }
        // GET: Reminder
        public ActionResult Index()
        {

             return View();
        }
    }
}