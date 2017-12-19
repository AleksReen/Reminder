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
    [Authorization(Roles = "User, Editor, Admin")]
    public class SearchController : Controller
    {
        private ICategoryProvider _providerCategory;
        private IReminderProvider _providerReminder;

        public SearchController(ICategoryProvider providerC, IReminderProvider providerR)
        {
            if (providerC == null)
            {
                throw new ArgumentException("Parameter cannot be null", "providerC");
            }
            _providerCategory = providerC;

            if (providerR == null)
            {
                throw new ArgumentException("Parameter cannot be null", "providerR");
            }
            _providerReminder = providerR;
        }

        public ActionResult SearchList()
        {          
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
           
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

                IReadOnlyList<MyReminder> model = _providerReminder.GetReminders(user.UserId);

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