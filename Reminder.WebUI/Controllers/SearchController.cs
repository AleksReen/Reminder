using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.HelperMethods;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User")]
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
            ViewBag.Result = true;

            if (!string.IsNullOrEmpty(filter.Name) || filter.Category != default(int) || filter.Date != default(DateTime))
            {
                var user = User as UserPrincipal;
                var searchList = new List<MyReminder>();

                IReadOnlyList<MyReminder> model = _provider.GetReminders(user.UserId);

                if (!string.IsNullOrEmpty(filter.Name))
                {

                    var result = model.Where(x => x.Title.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
                    if (result.Any())
                    {
                        foreach (var item in result)
                        {
                            searchList.Add(item);
                        }
                    }
                }

                if (filter.Category != default(int))
                {
                    var result = model.Where(x => x.CategoryId == filter.Category);

                    if (result.Any())
                    {
                        foreach (var item in result)
                        {
                            searchList.Add(item);
                        }
                    }
                }

                if (filter.Date != default(DateTime))
                {
                    var result = model.Where(x => x.Date == filter.Date);

                    if (result.Any())
                    {
                        foreach (var item in result)
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
            }

            ViewBag.Result = false;
            ViewBag.Message = "Sorry, you do not have any reminders matching the parameters";

            return PartialView("_SearchResult");
        }
    }
}