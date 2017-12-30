using Reminder.Common.Enums;
using Newtonsoft.Json;
using System.ServiceModel;
using System.Web.Security;
using System;
using System.Web;
using Reminder.Common.Entity;
using System.Collections.Generic;
using log4net;

namespace Reminder.Data.Clients
{
    public class UserClient : IUserClient
    {
        private ILog logger;

        public UserClient()
        {
            logger = LogManager.GetLogger("LOGGER");
        }
        public ServerResponse DeleteUser(int id)
        {
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.DeleteUser(id);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }
            return ServerResponse.DataBaseError;
        }

        public UserReminder GetEditeUser(int id)
        {
            var user = new UserReminder();
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var userDto = client.EditeUser(id);

                    if (userDto != null)
                    {
                        user.UserId = userDto.UserId;
                        user.Login = userDto.Login;
                        user.Email = userDto.Email;

                        var role = new UserRole()
                        {
                            RoleId = userDto.UserRole.RoleId,
                            RoleName = userDto.UserRole.RoleName
                        };
                        user.UserRole = role;
                    }
                    client.Close();
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }
            return user;
        }

        public IReadOnlyList<UserRole> GetRoles()
        {
            var roleList = new List<UserRole>();
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var rolesDto = client.GetRoles();

                    if (rolesDto != null)
                    {
                        foreach (var role in rolesDto)
                        {
                            var r = new UserRole
                            {
                                RoleId = role.RoleId,
                                RoleName = role.RoleName
                            };
                            
                            roleList.Add(r);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }
            return roleList;
        }

        public IReadOnlyList<UserReminder> GetUsers()
        {
            var listUsers = new List<UserReminder>();
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var usersDto = client.GetUsers();

                    if (usersDto != null)
                    {
                        foreach (var user in usersDto)
                        {
                            var u = new UserReminder()
                            {
                                UserId = user.UserId,
                                Login = user.Login,
                                Email = user.Email, 
                            };

                            var role = new UserRole
                            {
                                RoleId = user.UserRole.RoleId,
                                RoleName = user.UserRole.RoleName
                            };
                            u.UserRole = role;

                            listUsers.Add(u);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }
            return listUsers;
        }

        public ServerResponse Login(string login, string password)
        {
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.GetCurrentUser(login,password);

                    if (resultDto.UserId != default(int) && !string.IsNullOrEmpty(resultDto.Login))
                    {
                        var user = new UserReminder()
                        {
                            UserId = resultDto.UserId,
                            Login = resultDto.Login,
                        };

                        var role = new UserRole()
                        {
                           RoleName = resultDto.UserRole.RoleName
                        };

                        user.UserRole = role;

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
                    logger.Error(ex.Detail.Message);
                }
            }
            
            return ServerResponse.EmptyCredentials;
        }

        public ServerResponse Registration(string login, string password, string email)
        {                
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.Registration(login, password, email);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.RegistrationFaild;
        }

        public ServerResponse UpdatePassword(int id, string password)
        {
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.UpdatePassword(id, password);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

        public ServerResponse UpdateProfile(int id, string login, string email)
        {
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.UpdateProfile(id, login, email);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }
   
        public ServerResponse UpdateUser(int id, string login, string email, int roleId)
        {
            using (var client = new ReminderService.UserServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.UpdateUser(id, login, email, roleId);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }
    }
}
