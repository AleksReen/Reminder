﻿using Reminder.Business.Providers;
using Reminder.WebUI.Filters;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class CategoryController : Controller
    {
        private ICategoryProvider _provider;

        public CategoryController(ICategoryProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provider");
            }
            _provider = provider;
        }

        public ActionResult CategoryList()
        {          
            var categories = _provider.GetCategories().OrderBy(x => x.CategoryName);

            return PartialView("_CategoryList", categories);
        }

        public ActionResult GetCategoryName(int id)
        {
            var categoryName = _provider.GetCategories().Single(x => x.CategoryId == id).CategoryName;

            return PartialView("_GetCategoryName", categoryName);
        }
    }
}