using Reminder.Business.Providers;
using System;
using Reminder.Common.Enums;
using System.Web.Security;
using Reminder.Data.DataProviders;

namespace Reminder.Business.Model
{
    public class LoginProvider : ILoginProvider
    {
        private IDataRepository _dataProvider;

        public LoginProvider(IDataRepository provider)
        {
            _dataProvider = provider;
        }

        public LoginResult Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(login))
            {
                return LoginResult.InvalidCredentials;
            }
            else
            {
                return _dataProvider.Login(string login, string password);
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }  
    }
}
