using Reminder.Common.Enums;
using System.Text;
using Newtonsoft.Json;
using System.ServiceModel;
using System.Web.Security;
using System;
using System.Web;
using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.Clients
{
    public class UserClient : IUserClient
    {
        public IReadOnlyList<User> GetUsers()
        {
            var listUsers = new List<User>();
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var usersDto = client.GetUsers();

                    if (usersDto != null)
                    {
                        foreach (var user in usersDto)
                        {
                            var u = new User()
                            {
                                UserId = user.UserId,
                                Login = user.Login,
                                Email = user.Email,
                            };
                            foreach (var role in user.Roles)
                            {
                                var r = new Role();
                                r.RoleName = role;
                                u.Roles.Add(r);
                            }
                            listUsers.Add(u);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }

            }
            return listUsers;
        }

        public ServerResponse Login(string login, string password)
        {
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.GetCurrentUser(login,password);

                    if (resultDto.UserId != default(int) && !string.IsNullOrEmpty(resultDto.Login))
                    {
                        var user = new User()
                        {
                            UserId = resultDto.UserId,
                            Login = resultDto.Login
                        };
                        foreach (var item in resultDto.Roles)
                        {
                            var role = new Role() { RoleName = item };
                            user.Roles.Add(role);
                        }

                        var userData = JsonConvert.SerializeObject(user);
                        var ticket = new FormsAuthenticationTicket(2, login, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                        var encTicket = FormsAuthentication.Encrypt(ticket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                        HttpContext.Current.Response.Cookies.Add(authCookie);

                        return ServerResponse.NoError;
                    }

                    client.Close();

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }
            }
            
            return ServerResponse.EmptyCredentials;
        }

        public ServerResponse Registration(string login, string password, string email)
        {                
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.Registration(login, password, email);

                    if (resultDto.Result == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }

                    client.Close();

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }
            }

            return ServerResponse.RegistrationFaild;
        }
    }
}
