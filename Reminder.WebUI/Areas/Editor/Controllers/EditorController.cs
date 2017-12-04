using Reminder.WebUI.Filters;
using System.Web.Mvc;

namespace Reminder.WebUI.Areas.Editor.Controllers
{
    [Authorization(Roles = "Editor, Admin")]
    public class EditorController : Controller
    {    
        public ActionResult Index()
        {
            return View();
        }
    }
}