using Reminder.Business.Providers;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    //the controller processes a separate reminder
    public class ReminderItemController : Controller
    {
        private IReminderProvider _provider;

        public ReminderItemController(IReminderProvider provider)
        {
            _provider = provider;
        }
        
        //method returns a page with reminder details
        public ActionResult GetDetails(int reminderId)
        {
            var model = _provider.GetReminderInfo(reminderId);
           
            return View(model);
        }
        
        //method returns the value of the category for the reminder
        public ActionResult GetItemCategory(int id)
        {
            var categoryName = _provider.GetCategories().Single(x => x.CategoryId == id).CategoryName;
 
            return PartialView("_GetItemCategory", categoryName);
        }
    }
}