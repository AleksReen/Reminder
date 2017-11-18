using Reminder.Business.Providers;
using Reminder.WebUI.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
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
            ViewCategoryList model = new ViewCategoryList();
            model.Categories = _provider.GetCategory;

            return PartialView("_CategoryList", model);
        }
    }
}