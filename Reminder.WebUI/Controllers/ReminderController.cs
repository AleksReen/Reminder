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
        private IFakeInterface _dependency;

        public ReminderController(IFakeInterface dep)
        {
            _dependency = dep;
        }
        // GET: Reminder
        public ActionResult Index()
        {
            ViewBag.StaticMessage = _dependency.GetStaticMessage();

            try
            {
                _dependency.CreateSomeError();
            }
            catch (Exception er)
            {
                Logger.Log.Error(er);
            }

             return View();
        }
    }
}