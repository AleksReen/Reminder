using Reminder.Common.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Reminder.WebUI.Models.Entity
{
    public class UserPrincipal: IPrincipal
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string  Roles { get; set; }

        public IIdentity Identity
        {
            get; private set;
        }

        public UserPrincipal(string Login)
        {
            Identity = new GenericIdentity(Login);
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });

            if (role.Contains(Roles))
            {
                return true;
            }

            return false;
        }
    }
}