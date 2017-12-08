using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System.Collections.Generic;

namespace Reminder.Data.DataProviders
{
    public interface IUserRepository
    {
        ServerResponse Login(string login, string password);
        ServerResponse Registration(string login, string password, string email);
        ServerResponse UpdateUser(int id, string login, string email, int roleId);
        IReadOnlyList<UserReminder> GetUsers();
        IReadOnlyList<UserRole> GetRoles();
        UserReminder GetEditeUser(int id);
    }
}
