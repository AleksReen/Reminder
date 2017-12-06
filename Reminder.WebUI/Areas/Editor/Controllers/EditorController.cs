using Reminder.Business.Providers;
using Reminder.Common.Entity;
using Reminder.Common.Enums;
using Reminder.WebUI.Areas.Editor.Models;
using Reminder.WebUI.Filters;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Areas.Editor.Controllers
{
    [Authorization(Roles = "Editor, Admin")]
    public class EditorController : Controller
    {
        private ICategoryProvider _providerCategory;

        public EditorController(ICategoryProvider provider)
        {
            _providerCategory = provider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCategory()
        {
            return PartialView("_CreateCategory");
        }

        [HttpPost]
        public ActionResult CreateCategory(ViewModelCreateCategory category)
        {
            if (ModelState.IsValid)
            {
                var result = _providerCategory.AddCategory(category.CategoryName);
                if (result == ServerResponse.NoError)
                {
                    category.Message = "Category added";
                }
                if (result == ServerResponse.DataBaseError)
                {
                    category.Message = "Error adding to the database";
                }
                return PartialView("_CreateCategory", category);
            }
            return PartialView("_CreateCategory");
        }

        public ActionResult EditeCategory()
        {
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return PartialView("_EditeCategory");
        }
        [HttpPost]
        public ActionResult EditeCategory(ViewModelEditeCategory editCategory)
        {
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return PartialView("_EditeCategory");
        }
    }
}