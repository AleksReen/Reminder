using Reminder.Business.Providers;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    //the controller processes the reminder page
    public class ReminderController : Controller
    {
        private IReminderProvider _provider;

        public ReminderController(IReminderProvider prov)
        {
            _provider = prov;
        }

        //method returns a list of reminders with the category
        // GET: Reminder
        public ActionResult ReminderList(int? category)
        {
            var reminders = _provider.GetReminders()
                                                    .Where(c => category == null || c.CategoryId == category)
                                                    .OrderBy(c => c.Date);                                                  
            return View(reminders);
        }
    }
}