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
        ServerResponse UpdateUser(int id, string login, string email, int roleId);
        IReadOnlyList<UserReminder> GetUsers();
        IReadOnlyList<UserRole> GetRoles();
        UserReminder GetEditeUser(int id);
        
    }
}
