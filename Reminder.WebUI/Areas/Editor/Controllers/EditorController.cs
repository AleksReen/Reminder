using Reminder.Business.Providers;
using Reminder.Common.Enums;
using Reminder.WebUI.Areas.Editor.Models;
using Reminder.WebUI.Filters;
using System.Web.Mvc;

namespace Reminder.WebUI.Areas.Editor.Controllers
{
    [Authorization(Roles = "Editor, Admin")]
    public class EditorController : Controller
    {
        private IReminderProvider _provider;

        public EditorController(IReminderProvider provider)
        {
            _provider = provider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCategory()
        {
            return PartialView("_CreateCategoty");
        }

        [HttpPost]
        public ActionResult CreateCategory(ViewModelCreateCategory category)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = _provider.AddCategory(category.CategoryName);
            //    if (result = ServerResponse.NoError)
            //    {
            //        category.Message = "Category added";
            //    }
            //    if (result = ServerResponse.DataBaseError)
            //    {
            //        category.Message = "Error adding to the database";
            //    }
            //    return PartialView("_CreateCategoty", category);
            //}
            return PartialView("_CreateCategoty");
        }
    }
}