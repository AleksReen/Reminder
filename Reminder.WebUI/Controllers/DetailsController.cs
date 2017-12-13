using Reminder.Business.Providers;
using Reminder.WebUI.Filters;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class DetailsController : Controller
    {
        private IReminderProvider _provider;

        public DetailsController(IReminderProvider provider)
        {
            _provider = provider;
        }
        
        public ActionResult GetDetails(int reminderId)
        {
            var model = _provider.GetReminderInfo(reminderId);
           
            return PartialView("_Details", model);
        }
    }
}