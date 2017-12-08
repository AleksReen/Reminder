using Reminder.Business.Providers;
using Reminder.WebUI.Filters;
using Reminder.WebUI.Models.Entity;
using Reminder.WebUI.Models.ViewsModels;
using System.Linq;
using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    [Authorization(Roles = "User, Editor, Admin")]
    public class ReminderController : Controller
    {
        private IReminderProvider _provider;

        public ReminderController(IReminderProvider prov)
        {
            _provider = prov;
        }

        public ActionResult ReminderList(int? category)
        {
            var model = new ViewReminderList();
            var user = User as UserPrincipal;
            var reminders = _provider.GetReminders(user.UserId)
                                                   .Where(c => category == null || c.CategoryId == category)
                                                   .OrderBy(c => c.Date);
            model.CurrentUser = user;
            model.Reminders = reminders;

            return View(model);
        }
    }
}