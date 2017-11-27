﻿using Reminder.Service.Contracts.Models.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Reminder.Service
{
    public class ReminderService : IReminderService
    {
        SqlConnection sqlCn = new SqlConnection();
        string connectionString = ConfigurationManager.ConnectionStrings["ReminderBase"].ConnectionString;

        public List<CategoryDto> GetAllCategories()
        {
            sqlCn.ConnectionString = connectionString;
            var categoriesList = new List<CategoryDto>();

            using (var cmd = new SqlCommand("GetAllCategories", sqlCn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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
            return categoriesList;
        }

        public List<MyReminderDto> GetAllReminders()
        {
            sqlCn.ConnectionString = connectionString;
            var remindersList = new List<MyReminderDto>();

            using (var cmd = new SqlCommand("GetAllReminders", sqlCn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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
            return remindersList;
        }

        public ReminderInfoDto GetReminderInfo(int reminderId)
        {
            sqlCn.ConnectionString = connectionString;
            var reminderInfo = new ReminderInfoDto();

            using (var cmd = new SqlCommand("GetReminderInfo", sqlCn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", reminderId);

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
            return reminderInfo;
        }
    }
}
