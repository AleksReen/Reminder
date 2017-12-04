using Reminder.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login", area = "" }));
                
            }

            if (user != null)
            {
                if (!user.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Access", action = "Denied", area = "" }));
                }
            }
            
        }
    }
}