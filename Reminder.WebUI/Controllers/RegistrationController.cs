using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(ViewRegistration regForm)
        {
            return View();
        }
    }
}