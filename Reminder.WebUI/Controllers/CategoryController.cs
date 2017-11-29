﻿using Reminder.Business.Providers;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    //the controller processes the navigation menu
    public class CategoryController : Controller
    {
        private IReminderProvider _provider;

        public CategoryController(IReminderProvider provider)
        {
            _provider = provider;
        }

        // GET: Category
        public ActionResult CategoryList()
        {          
            var categories = _provider.GetCategories().OrderBy(x => x.CategoryName);

            return PartialView("_CategoryList", categories);
        }
    }
}