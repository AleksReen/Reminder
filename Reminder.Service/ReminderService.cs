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
    public class ReminderService : IReminderService
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

        public CategoryDto [] GetAllCategories()
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

        public MyReminderDto [] GetAllReminders(int userId)
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

        public ServerResultDto AddCategory(string categoryName)
        {
            var result = new ServerResultDto();

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
                        result.Result = (int)returnParameter.Value;

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return result;
                }
            }
        }

        public ServerResultDto EditeCategory(int categoryId, string categoryName)
        {
            var result = new ServerResultDto();

            using (var sqlCn = new SqlConnection(connectionString))
            {

                using (var cmd = new SqlCommand("EditeCategory", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        result.Result = (int)returnParameter.Value;

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return result;
                }
            }
        }

        public ServerResultDto DeleteCategory(int categoryId)
        {
            var result = new ServerResultDto();

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
                        result.Result = (int)returnParameter.Value;

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return result;
                }
            }
        }

        public ServerResultDto Registration(string login, string password, string email)
        {
            var result = new ServerResultDto();

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
                        result.Result = (int)returnParameter.Value;

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return result;
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

        public ServerResultDto UpdateUser(int id, string login, string email, int roleId)
        {
            var result = new ServerResultDto();

            using (var sqlCn = new SqlConnection(connectionString))
            {

                using (var cmd = new SqlCommand("UpdateUser", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@roleId", roleId);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        sqlCn.Open();

                        cmd.ExecuteNonQuery();
                        result.Result = (int)returnParameter.Value;

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return result;
                }
            }
        }

        public ServerResultDto DeleteUser(int id)
        {
            var result = new ServerResultDto();

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
                        result.Result = (int)returnParameter.Value;

                        sqlCn.Close();
                    }
                    catch (Exception e)
                    {
                        error.Message = e.Message;
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                    return result;
                }
            }
        }
    }
}
