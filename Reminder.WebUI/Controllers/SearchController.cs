using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.HelperMethods;
using Reminder.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class SearchController : Controller
    {
        private IReminderProvider _provider;
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
            //TO DO
            ViewBag.result = false;

            if (!string.IsNullOrEmpty(name)) {

                var user = User as UserPrincipal;
                IEnumerable<MyReminder> model = _provider.GetReminders(user.UserId).
                                                                       Where(x => x.Title.Contains(name, StringComparison.OrdinalIgnoreCase));
                ViewBag.result = true;
                return PartialView("_SearchResult", model);
            }

            return new EmptyResult();
        }
    }
}