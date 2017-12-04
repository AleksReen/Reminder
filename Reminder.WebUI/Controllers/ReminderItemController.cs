using Reminder.Business.Providers;
using Reminder.WebUI.Filters;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User")]
    public class ReminderItemController : Controller
    {
        private IReminderProvider _provider;

        public ReminderItemController(IReminderProvider provider)
        {
            _provider = provider;
        }
        
        public ActionResult GetDetails(int reminderId)
        {
            var model = _provider.GetReminderInfo(reminderId);
           
            return View(model);
        }
        
        public ActionResult GetItemCategory(int id)
        {
            var categoryName = _provider.GetCategories().Single(x => x.CategoryId == id).CategoryName;
 
            return PartialView("_GetItemCategory", categoryName);
        }
    }
}