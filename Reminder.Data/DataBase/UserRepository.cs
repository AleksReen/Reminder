using Reminder.Data.DataProviders;
using Reminder.Common.Enums;
using Reminder.Data.Clients;
using System;

namespace Reminder.Data.DataBase
{
    public class UserRepository : IUserRepository
    {
        private IUserClient _userClient;

        public UserRepository(IUserClient user)
        {
            _userClient = user;
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
