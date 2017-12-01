﻿using Newtonsoft.Json;
using Reminder.Service.Contracts.Models.Dto;
using Reminder.Service.ModelDto.Dto;
using Reminder.Service.ModelDto.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Web;
using System.Web.Security;

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
            catch (Exception)
            {
                error.Message = "conection string error";
                throw new FaultException<ServiceErrorDto>(error, "DataBase Error");
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
                    catch (SqlException)
                    {
                        error.Message = "error reading data from the database";
                        throw new FaultException<ServiceErrorDto>(error, "DataBase Error");
                    }
                }
            }
                      
            return categoriesList.ToArray();
        }

        public MyReminderDto [] GetAllReminders()
        {
            var remindersList = new List<MyReminderDto>();

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetAllReminders", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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
                    catch (SqlException)
                    {
                        error.Message = "error reading data from the database";
                        throw new FaultException<ServiceErrorDto>(error, "DataBase Error");
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
                    catch (SqlException)
                    {
                        error.Message = "error reading data from the database";
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }
                }
            }
              
            return reminderInfo;
        }

        public LoginResultDto Login(string login, string password)
        {
            var user = new User() { Roles = new List<string>()};

            using (var sqlCn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("GetLogin", sqlCn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

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
                                    user.Roles.Add(reader["Role"].ToString());
                                }
                                else
                                {
                                    user.Roles.Add(reader["Role"].ToString());
                                }
                            };
                        }

                        sqlCn.Close();
                    }
                    catch (SqlException)
                    {
                        error.Message = "error reading data from the database";
                        throw new FaultException<ServiceErrorDto>(error, "Database error");
                    }


                    if (user.UserId != default(int))
                    {
                        var userData = JsonConvert.SerializeObject(user);
                        var ticket = new FormsAuthenticationTicket(2, login, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                        var encTicket = FormsAuthentication.Encrypt(ticket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                       
                        HttpContext.Current.Response.Cookies.Add(authCookie);
                       
                        return LoginResultDto.NoError;
                    }
                    else
                    {
                        //TO DO
                        return LoginResultDto.EmptyCredentials;
                    }
                }
            }
        }
    }
}
