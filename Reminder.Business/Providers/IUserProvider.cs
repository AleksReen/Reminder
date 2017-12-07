using Reminder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Business.Providers
{
   public interface IUserProvider
   {
        ServerResponse Login(string login, string password);
        ServerResponse Registration(string login, string password, string email);
        void Logout();
    }
}
