using Reminder.WebUI.Models.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Reminder.WebUI.Filters
{
    public class AuthorizationAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as UserPrincipal;

            if (user == null || !user.IsInRole(Roles))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Access", action = "Denied", area = "" }));              
            }            
        }
    }
}