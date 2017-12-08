using Reminder.Data.DataProviders;
using Reminder.Common.Enums;
using Reminder.Data.Clients;
using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.DataBase
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
    }
}
