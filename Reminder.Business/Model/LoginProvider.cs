using Reminder.Business.Providers;
using Reminder.Common.Enums;
using System.Web.Security;
using Reminder.Data.DataProviders;

namespace Reminder.Business.Model
{
    public class LoginProvider : ILoginProvider
    {
        private IUserRepository _userProvider;

        public LoginProvider(IUserRepository provider)
        {
            _userProvider = provider;
        }

        public LoginResult Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return LoginResult.InvalidCredentials;
            }
            else
            {
                return _userProvider.Login(login, password);
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }  
    }
}
