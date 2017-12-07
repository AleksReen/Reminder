using Reminder.Common.Entity;
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
        ServerResponse Login(string login, string password);
        ServerResponse Registration(string login, string password, string email);
        IReadOnlyList<User> GetUsers();
    }
}
