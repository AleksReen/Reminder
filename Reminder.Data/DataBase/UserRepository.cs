using Reminder.Data.DataProviders;
using Reminder.Common.Enums;
using Reminder.Data.Clients;

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
    }
}
