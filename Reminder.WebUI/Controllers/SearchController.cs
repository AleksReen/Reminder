using Reminder.Business.Providers;
using Reminder.Business.ReminderCache;
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
    [Authorization(Roles = "User, Editor, Admin")]
    public class SearchController : Controller
    {
        private readonly string cacheKeyCategory = "Categories";
        private readonly string cacheKeyReminders = "Reminders";
        private ICategoryProvider _providerCategory;
        private IReminderProvider _providerReminder;
        private IAppCache _cache;

        public SearchController(ICategoryProvider providerC, IReminderProvider providerR, IAppCache cache)
        {
            if (providerC == null || providerR == null || cache == null)
            {
                throw new ArgumentException("Parameter cannot be null");
            }
            _providerCategory = providerC;
            _providerReminder = providerR;
            _cache = cache;
        }

        public ActionResult SearchList(string message, bool? resultAction)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
                ViewBag.Result = (bool)resultAction;
            }

            ViewBag.Category = _cache.GetValue(cacheKeyCategory,
                   () => _providerCategory.GetCategories().OrderBy(x => x.CategoryName));

            return View();
        }
        public ActionResult GetSearchResult()
        {
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult GetSearchResult(ViewFilter filter)
        {
            if (filter == null)
            {  
                throw new NullReferenceException();
            }
        
            ViewBag.Result = true;

            if (!string.IsNullOrEmpty(filter.Name) || filter.Category != default(int) || filter.Date != default(DateTime))
            {
                var searchList = new List<MyReminder>();
                var user = User as UserPrincipal;
                
                var model = _cache.GetValue(cacheKeyReminders, () => _providerReminder.GetReminders(user.UserId));

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
                    var result = model.Where(x => x.Category.CategoryId == filter.Category);

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
                    var result = searchList.Distinct();
                    return PartialView("_SearchResult", result);
                }
            }

            ViewBag.Result = false;
            ViewBag.Message = "Sorry, you do not have any reminders matching the parameters";

            return PartialView("_SearchResult");
        }
    }
}