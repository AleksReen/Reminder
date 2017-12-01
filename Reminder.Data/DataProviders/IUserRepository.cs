using Reminder.Common.Enums;

namespace Reminder.Data.DataProviders
{
    public interface IUserRepository
    {
        LoginResult Login(string login, string password);
    }
}
