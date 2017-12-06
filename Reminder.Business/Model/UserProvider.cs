﻿using Reminder.Business.Providers;
using Reminder.Common.Enums;
using System.Web.Security;
using Reminder.Data.DataProviders;

namespace Reminder.Business.Model
{
    public class UserProvider : IUserProvider
    {
        private IUserRepository _userProvider;

        public UserProvider(IUserRepository provider)
        {
            _userProvider = provider;
        }

        public ServerResponse Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return ServerResponse.InvalidCredentials;
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