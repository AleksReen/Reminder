using Reminder.Data.Repository;
using Reminder.Common.Enums;
using Reminder.Data.Clients;
using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private IUserClient _userClient;

        public UserRepository(IUserClient user)
        {
            _userClient = user;
        }

        public IReadOnlyList<UserReminder> GetUsers()
        {
            return _userClient.GetUsers();
        }

        public UserReminder GetEditeUser(int id)
        {
            return _userClient.GetEditeUser(id);
        }

        public ServerResponse Login(string login, string password)
        {
            return _userClient.Login(login, password);
        }

        public ServerResponse Registration(string login, string password, string email)
        {
            return _userClient.Registration(login, password, email);
        }

        public IReadOnlyList<UserRole> GetRoles()
        {
            return _userClient.GetRoles();
        }

        public ServerResponse UpdateUser(int id, string login, string email, int roleId)
        {
            return _userClient.UpdateUser(id, login, email, roleId);
        }

        public ServerResponse DeleteUser(int id)
        {
            return _userClient.DeleteUser(id);
        }

        public ServerResponse UpdateProfile(int id, string login, string email)
        {
            return _userClient.UpdateProfile(id, login, email);
        }

        public ServerResponse UpdatePassword(int id, string password)
        {
            return _userClient.UpdatePassword(id, password);
        }
    }
}
