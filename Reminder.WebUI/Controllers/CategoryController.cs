using Reminder.Business.Providers;
using Reminder.Business.ReminderCache;
using Reminder.WebUI.Filters;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class CategoryController : Controller
    {
        private readonly string cacheKeyCategory = "Categories";
        private ICategoryProvider _provider;
        private IAppCache _cache;

        public CategoryController(ICategoryProvider provider, IAppCache cache)
        {
            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provider");
            }
            _provider = provider;

            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null", "cache");
            }
            _cache = cache;
        }

        public ActionResult CategoryList()
        {
            var categories = _cache.GetValue(cacheKeyCategory, 
                    () => _provider.GetCategories().OrderBy(x => x.CategoryName));
 
            return PartialView("_CategoryList", categories);
        }
    }
}