using Reminder.Service.Contracts.Contracts;
using Reminder.Service.Contracts.Models.Dto;
using Reminder.Service.ModelDto.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace Reminder.Service
{
    public class ReminderService : IReminderService, IUserService, ICategoryService
    {
        private readonly string connectionString;
        private readonly ServiceErrorDto error;

        public ReminderService()
        {
            error = new ServiceErrorDto();
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ReminderBase"].ConnectionString;
            }
            catch (Exception e)
            {
                error.Message = e.Message;
                throw new FaultException<ServiceErrorDto>(error, "Database error");
            }

        }

        public CategoryDto[] GetAllCategories()
        {
            var categoriesList = new List<CategoryDto>();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetAllCategories", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        sqlCn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var category = new CategoryDto()
                                {
                                    CategoryId = (int)reader["CategoryId"],
                                    CategoryName = reader["CategoryName"].ToString()
                                };
                                categoriesList.Add(category);
                            }
                        };

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }

            return categoriesList.ToArray();
        }

        public MyReminderDto[] GetAllReminders(int userId)
        {
            var remindersList = new List<MyReminderDto>();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetAllReminders", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        sqlCn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var reminder = new MyReminderDto()
                                {
                                    ReminderId = (int)reader["ReminderId"],
                                    Title = reader["Title"].ToString(),
                                    Date = (DateTime)reader["Date"],
                                    ReminderTime = (DateTime)reader["ReminderTime"],
                                    Image = reader["Image"].ToString(),
                                    CategoryId = (int)reader["CategoryId"]
                                };
                                remindersList.Add(reminder);
                            }
                        }

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }

            return remindersList.ToArray();
        }

        public ReminderInfoDto GetReminderInfo(int reminderId)
        {
            var reminderInfo = new ReminderInfoDto();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetReminderInfo", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", reminderId);

                    try
                    {
                        sqlCn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reminderInfo.Reminder.ReminderId == default(int))
                                {
                                    reminderInfo.Reminder.ReminderId = (int)reader["ReminderId"];
                                    reminderInfo.Reminder.Title = reader["Title"].ToString();
                                    reminderInfo.Reminder.Date = (DateTime)reader["Date"];
                                    reminderInfo.Reminder.ReminderTime = (DateTime)reader["ReminderTime"];
                                    reminderInfo.Reminder.Image = reader["Image"].ToString();
                                    reminderInfo.Reminder.CategoryId = (int)reader["CategoryId"];

                                    reminderInfo.Category = reader["CategoryName"].ToString();
                                    reminderInfo.Description = reader["Description"].ToString();

                                    reminderInfo.Actions.Add(reader["Action"].ToString());
                                }
                                else
                                {
                                    reminderInfo.Actions.Add(reader["Action"].ToString());
                                }
                            };
                        }

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }

            return reminderInfo;
        }

        public UserDto GetCurrentUser(string login, string password)
        {
            var user = new UserDto();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetLogin", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (user.UserId == default(int))
                                {
                                    user.UserId = (int)reader["UserId"];
                                    user.Login = reader["Login"].ToString();
                                    var role = new RoleDto()
                                    {
                                        RoleName = reader["Role"].ToString()
                                    };
                                    user.UserRole = role;
                                }
                            };
                        }

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return user;
                }
            }
        }

        public int AddCategory(string categoryName)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {

                using (var cmd = new SqlCommand("CreateCategory", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@categoryName", categoryName);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public int EditeCategory(int categoryId, string categoryName)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("EditeCategory", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public int DeleteCategory(int categoryId)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("DeleteCategory", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public int Registration(string login, string password, string email)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("CreateUser", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public UserDto[] GetUsers()
        {
            var userList = new List<UserDto>();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetUsers", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        sqlCn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new UserDto()
                                {
                                    UserId = (int)reader["UserId"],
                                    Login = reader["Login"].ToString(),
                                    Email = reader["Email"].ToString()
                                };
                                var role = new RoleDto
                                {
                                    RoleId = (int)reader["RoleId"],
                                    RoleName = reader["Role"].ToString()
                                };

                                user.UserRole = role;

                                userList.Add(user);
                            }
                        }

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }

            return userList.ToArray();
        }

        public UserDto EditeUser(int id)
        {
            var user = new UserDto();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("EditeUser", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        sqlCn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.UserId = (int)reader["UserId"];
                                user.Login = reader["Login"].ToString();
                                user.Email = reader["Email"].ToString();
                                var role = new RoleDto
                                {
                                    RoleId = (int)reader["RoleId"],
                                    RoleName = reader["Role"].ToString()
                                };
                                user.UserRole = role;
                            };
                        }
                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return user;
                }
            }
        }

        public RoleDto[] GetRoles()
        {
            var roleList = new List<RoleDto>();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetRoles", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        sqlCn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var role = new RoleDto
                                {
                                    RoleId = (int)reader["RoleId"],
                                    RoleName = reader["Role"].ToString()
                                };

                                roleList.Add(role);
                            }
                        }

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
            return roleList.ToArray();
        }

        public int UpdateUser(int id, string login, string email, int roleId)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("UpdateUser", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@roleId", roleId);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public int DeleteUser(int id)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("DeleteUser", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public int UpdateProfile(int id, string login, string email)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("UpdateProfile", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@email", email);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public int UpdatePassword(int id, string password)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("UpdatePassword", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@newPassword", password);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }                   
                }
            }
        }

        public int AddReminder(string title, DateTime date, DateTime dateReminder, string image, int categoryId, int userId, string actions, string descriptions)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("AddReminder", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@dateReminder", dateReminder);
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@actions", actions);
                    cmd.Parameters.AddWithValue("@description", descriptions);
                    
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public string DeleteReminder(int id)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {

                using (var cmd = new SqlCommand("DeleteReminder", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReminderID", id);

                    var returnParameter = cmd.Parameters.Add("@imageUrl", SqlDbType.NVarChar);
                    returnParameter.Size = 500;
                    returnParameter.Direction = ParameterDirection.Output;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = returnParameter.Value.ToString();

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }

        public int UpdateReminder(int reminderId, string title, DateTime date, DateTime dateReminder, string image, int categoryId, string actions, string descriptions)
        {
            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("UpdateReminder", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@reminderId", reminderId);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@dateReminder", dateReminder);
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@actions", actions);
                    cmd.Parameters.AddWithValue("@description", descriptions);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        var result = (int)returnParameter.Value;

                        sqlCn.Close();

                        return result;
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
        }
    }
}
