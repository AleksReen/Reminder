using Reminder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data.Clients
{
    public interface IUserClient
    {
        LoginResult Login(string login, string password);  
    }
}
