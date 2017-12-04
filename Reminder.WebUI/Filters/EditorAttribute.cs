using Reminder.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Reminder.WebUI.Filters
{
    public class EditorAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as UserPrincipal;
            if (!user.IsInRole("Editor"))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Access", action = "Denied", area = ""}));
            }

        }
    }
}