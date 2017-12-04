using Reminder.Business.Providers;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User")]
    public class ReminderController : Controller
    {
        private IReminderProvider _provider;

        public ReminderController(IReminderProvider prov)
        {
            _provider = prov;
        }

        public ActionResult ReminderList(int? category)
        {
            var user = User as UserPrincipal;

            var reminders = _provider.GetReminders(user.UserId)
                                                   .Where(c => category == null || c.CategoryId == category)
                                                   .OrderBy(c => c.Date);   
            return View(reminders);
        }
    }
}