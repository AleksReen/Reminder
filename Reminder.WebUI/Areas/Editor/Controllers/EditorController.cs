using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Areas.Editor.Models;
using Reminder.WebUI.Filters;
using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Reminder.WebUI.Areas.Editor.Controllers
{
    [Authorization(Roles = "Editor, Admin")]
    public class EditorController : Controller
    {
        private ICategoryProvider _providerCategory;

        public EditorController(ICategoryProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provider");
            }
            _providerCategory = provider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCategory()
        {
            Thread.Sleep(2000);
            return PartialView("_CreateCategory");
        }

        [HttpPost]
        public ActionResult CreateCategory(ViewModelCreateCategory category)
        {
            Thread.Sleep(2000);
            if (ModelState.IsValid)
            {
                var result = _providerCategory.AddCategory(category.CategoryName);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
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
            Thread.Sleep(2000);
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return PartialView("_EditeCategory");
        }
        [HttpPost]
        public ActionResult EditeCategory(EditeCategory editeCategory)
        {
            Thread.Sleep(2000);
            if (ModelState.IsValid)
            {
                var result = _providerCategory.EditeCategory(editeCategory.CategoryId, editeCategory.NewName);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
                    return PartialView("_ResultEdite", editeCategory.NewName);
                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultEdite", editeCategory.NewName);
                }
            }

            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return PartialView("_EditeCategory");
        }

        public ActionResult DeleteCategory()
        {
            Thread.Sleep(2000);
            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return PartialView("_DeleteCategory");
        }
        [HttpPost]
        public ActionResult DeleteCategory(DeleteCategory deleteCategory)
        {
            Thread.Sleep(2000);
            if (ModelState.IsValid)
            {
                var result = _providerCategory.DeleteCategory(deleteCategory.CategoryId);
                if (result == ServerResponse.NoError)
                {
                    ViewBag.Result = true;
                    return PartialView("_ResultDelete");
                }
                if (result == ServerResponse.DataBaseError)
                {
                    ViewBag.Result = false;
                    return PartialView("_ResultDelete");
                }
            }

            ViewBag.Category = _providerCategory.GetCategories().OrderBy(x => x.CategoryName);
            return PartialView("_DeleteCategory");
        }
    }
}