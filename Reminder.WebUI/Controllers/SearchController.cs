using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.HelperMethods;
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
            ViewBag.result = false;

            if (!string.IsNullOrEmpty(name)) {
                
                IEnumerable<MyReminder> model = _provider.GetReminders.
                                                                       Where(x => x.Title.Contains(name, StringComparison.OrdinalIgnoreCase));
                ViewBag.result = true;
                return PartialView("_SearchResult", model);
            }

            return PartialView("_SearchResult");
        }
    }
}