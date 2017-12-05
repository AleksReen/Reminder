using Reminder.Common.Enums;

namespace Reminder.Data.DataProviders
{
    public interface IUserRepository
    {
        ServerResponse Login(string login, string password);
    }
}
