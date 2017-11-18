using Reminder.Business.Providers;
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
        
    }
}