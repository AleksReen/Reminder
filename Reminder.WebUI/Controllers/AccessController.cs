using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Denied()
        {
            return View();
        }
    }
}