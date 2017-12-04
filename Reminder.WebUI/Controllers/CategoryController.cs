using Reminder.Business.Providers;
using Reminder.WebUI.Filters;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User")]
    public class CategoryController : Controller
    {
        private IReminderProvider _provider;

        public CategoryController(IReminderProvider provider)
        {
            _provider = provider;
        }

        public ActionResult CategoryList()
        {          
            var categories = _provider.GetCategories().OrderBy(x => x.CategoryName);

            return PartialView("_CategoryList", categories);
        }
    }
}