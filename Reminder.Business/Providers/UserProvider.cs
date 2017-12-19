using Reminder.Common.Enums;
using System.Web.Security;
using Reminder.Data.Repository;
using Reminder.Common.Entity;
using System.Collections.Generic;
using System;

namespace Reminder.Business.Providers
{
    public class UserProvider : IUserProvider
    {
        private IUserRepository _userProvider;

        public UserProvider(IUserRepository provider)
        {
            if (provider == null)
            {
                throw new ArgumentException("Parameter cannot be null", "provider");
            }
            _userProvider = provider;
        }

        public ServerResponse DeleteUser(int id)
        {
            return _userProvider.DeleteUser(id);
        }

        public UserReminder GetEditeUser(int id)
        {
            return _userProvider.GetEditeUser(id);
        }

        public IReadOnlyList<UserRole> GetRoles()
        {
            return _userProvider.GetRoles();
        }

        public IReadOnlyList<UserReminder> GetUsers()
        {
            return _userProvider.GetUsers();
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

        public ServerResponse Registration(string login, string password, string email)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)|| string.IsNullOrEmpty(email))
            {
                return ServerResponse.InvalidCredentials;
            }
            else
            {
                return _userProvider.Registration(login, password, email);
            }
        }

        public ServerResponse UpdatePassword(int id, string password)
        {
            return _userProvider.UpdatePassword(id, password);
        }

        public ServerResponse UpdateProfile(int id, string login, string email)
        {
            return _userProvider.UpdateProfile(id, login, email);
        }

        public ServerResponse UpdateUser(int id, string login, string email, int roleId)
        {
            return _userProvider.UpdateUser(id, login, email, roleId);
        }
    }
}
