using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System.Collections.Generic;

namespace Reminder.Business.Providers
{
   public interface IUserProvider
   {
        ServerResponse Login(string login, string password);
        ServerResponse Registration(string login, string password, string email);
        ServerResponse UpdateUser(int id, string login, string email, int roleId);
        ServerResponse UpdateProfile(int id, string login, string email);
        ServerResponse UpdatePassword(int id, string password);
        ServerResponse DeleteUser(int id);
        void Logout();
        IReadOnlyList<UserReminder> GetUsers();
        IReadOnlyList<UserRole> GetRoles();
        UserReminder GetEditeUser(int id);
    }
}
