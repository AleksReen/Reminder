using Reminder.Service.Contracts.Models.Dto;
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
            List<CategoryDto> categoriesList = new List<CategoryDto>();

            using (SqlCommand cmd = new SqlCommand("GetAllCategories", sqlCn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                sqlCn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CategoryDto category = new CategoryDto()
                    {
                        CategoryId = (int)reader["CategoryId"],
                        CategoryName = reader["CategoryName"].ToString()
                    };
                    categoriesList.Add(category);
                }

                sqlCn.Close();
            }
            return categoriesList;
        }

        public List<MyReminderDto> GetAllReminders()
        {
            sqlCn.ConnectionString = connectionString;
            List<MyReminderDto> remindersList = new List<MyReminderDto>();

            using (SqlCommand cmd = new SqlCommand("GetAllReminders", sqlCn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                sqlCn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MyReminderDto reminder = new MyReminderDto()
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

                sqlCn.Close();
            }
            return remindersList;
        }
    }
}
