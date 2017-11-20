using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult SearchList()
        {
            return View();
        }

        public ActionResult GetSearchResult(string name, string date, string category)
        {
            ViewBag.name = name;
            ViewBag.date = date;
            ViewBag.category = category;
            return PartialView("_SearchResult");
        }
    }
}