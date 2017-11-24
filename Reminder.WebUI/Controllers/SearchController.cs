using Reminder.Business.Providers;
using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class SearchController : Controller
    {
        IReminderProvider _provider;
        // GET: Search

        public SearchController(IReminderProvider provider)
        {
            _provider = provider;
        }

        public ActionResult SearchList()
        {
            return View();
        }

        public ActionResult GetSearchResult(string name, string date, string category)
        {
            if (name != null || date !=null || category!=null) {
                IEnumerable<MyReminder> model = _provider.GetReminders.Where(x => x.Name.Contains(name));
                return PartialView("_SearchResult", model);
            }

            return HttpNotFound();
        }
    }
}