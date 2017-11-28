using System.Web.Mvc;

namespace Reminder.WebUI.Controllers
{
    //the controller processes the home page
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}