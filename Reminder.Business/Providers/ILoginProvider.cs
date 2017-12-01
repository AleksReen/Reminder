using Reminder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Business.Providers
{
   public interface ILoginProvider
   {
        LoginResult Login(string login, string password);
        void Logout();
    }
}
