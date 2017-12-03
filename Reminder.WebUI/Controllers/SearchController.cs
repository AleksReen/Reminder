using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.HelperMethods;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
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
            ViewBag.Category = _provider.GetCategories().OrderBy(x => x.CategoryName);
           
            return View();
        }
        public ActionResult GetSearchResult()
        {
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult GetSearchResult(ViewFilter filter)
        {
            var user = User as UserPrincipal;
            var searchList = new List<MyReminder>();


            if (!string.IsNullOrEmpty(filter.Name)) {
 
                IEnumerable<MyReminder> model = _provider.GetReminders(user.UserId).
                                                                       Where(x => x.Title.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
                if (!model.Any())
                {
                    foreach (var item in model)
                    {
                        searchList.Add(item);
                    }
                }
            }

            if (filter.Category != default(int))
            {
                IEnumerable<MyReminder> model = _provider.GetReminders(user.UserId).
                                                                      Where(x => x.CategoryId == filter.Category);

                if (!model.Any())
                {
                    foreach (var item in model)
                    {
                        searchList.Add(item);
                    }
                }
            }

            if (filter.Date != default(DateTime))
            {
                IEnumerable<MyReminder> model = _provider.GetReminders(user.UserId).
                                                                      Where(x => x.Date == filter.Date);

                if (!model.Any())
                {
                    foreach (var item in model)
                    {
                        searchList.Add(item);
                    }
                }
            }

            if (searchList.Any())
            {
                searchList.Distinct();
                return PartialView("_SearchResult", searchList);
            }

            return new EmptyResult();
        }
    }
}