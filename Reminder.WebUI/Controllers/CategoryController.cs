using Reminder.Business.Providers;
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
            var categories = _provider.GetCategory();

            return PartialView("_CategoryList", categories);
        }
    }
}