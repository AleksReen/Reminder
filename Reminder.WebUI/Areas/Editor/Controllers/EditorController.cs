using Reminder.Business.Providers;
using Reminder.Business.ReminderCache;
using Reminder.Common.Entity;
using Reminder.Common.Enums;
using Reminder.WebUI.Areas.Editor.Models;
using Reminder.WebUI.Filters;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Areas.Editor.Controllers
{
    [Authorization(Roles = "Editor, Admin")]
    public class EditorController : Controller
    {
        private readonly string cacheKeyCategory = "Categories";
        private ICategoryProvider _providerCategory;
        private IAppCache _cache;

        public EditorController(ICategoryProvider provider, IAppCache cache)
        {
            if (provider == null || cache == null)
            {
                throw new ArgumentException("Parameter cannot be null");
            }
            _providerCategory = provider;
            _cache = cache;
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
                    ViewBag.Result = true;
                    _cache.RemoveValue(cacheKeyCategory);
                    return PartialView("_ResultCreate", category.CategoryName);
                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultCreate", category.CategoryName);
                } 
            }

            return PartialView("_CreateCategory");
        }

        public ActionResult EditeCategory()
        {
            ViewBag.Category = GetCategories();
            return PartialView("_EditeCategory");
        }
        [HttpPost]
        public ActionResult EditeCategory(EditeCategory editeCategory)
        {
            if (ModelState.IsValid)
            {
                var result = _providerCategory.EditeCategory(editeCategory.CategoryId, editeCategory.NewName);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
                    _cache.RemoveValue(cacheKeyCategory);
                    return PartialView("_ResultEdite", editeCategory.NewName);
                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultEdite", editeCategory.NewName);
                }
            }

            ViewBag.Category = GetCategories();
            return PartialView("_EditeCategory");
        }

        public ActionResult DeleteCategory()
        {
            ViewBag.Category = GetCategories();
            return PartialView("_DeleteCategory");
        }
        [HttpPost]
        public ActionResult DeleteCategory(DeleteCategory deleteCategory)
        {
            if (ModelState.IsValid)
            {
                var result = _providerCategory.DeleteCategory(deleteCategory.CategoryId);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
                    _cache.RemoveValue(cacheKeyCategory);
                    return PartialView("_ResultDelete");
                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultDelete");
                }
            }

            ViewBag.Category = GetCategories();
            return PartialView("_DeleteCategory");
        }

        private IOrderedEnumerable<Category> GetCategories()
        {
            return _cache.GetValue(cacheKeyCategory,
                   () => _providerCategory.GetCategories().OrderBy(x => x.CategoryName));
        }
    }
}