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
                        CategoryId = (int)reader["CategoryId"],
                        CategoryName = reader["CategoryName"].ToString()
                    };
                    remindersList.Add(category);
                }

                sqlCn.Close();
            }
            return categoriesList;
        }

    //    //fake table Reminder
    //    List<MyReminderDto> ReminderList = new List<MyReminderDto>()
    //    {
    //        new MyReminderDto { ReminderId = 1,
    //                         Name = "repair the car",
    //                         Date = Convert.ToDateTime("17.11.2017"),
    //                         Description = "Test",
    //                         Action = "Test",
    //                         ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
    //                         CategoryId = 1,
    //                         ImageId = 1
    //                       },
    //        new MyReminderDto { ReminderId = 2,
    //                         Name = "Meeting with family",
    //                         Date = Convert.ToDateTime("18.11.2017"),
    //                         Description = "Test2",
    //                         Action = "Test2",
    //                         ReminderTime = Convert.ToDateTime("18.11.2017 12:45"),
    //                         CategoryId = 2,
    //                         ImageId = 1
    //                       },
    //        new MyReminderDto { ReminderId = 3,
    //                         Name = "To have a deal",
    //                         Date = Convert.ToDateTime("17.11.2017"),
    //                         Description = "Test3",
    //                         Action = "Test3",
    //                         ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
    //                         CategoryId = 3,
    //                         ImageId = 1
    //                       },
    //        new MyReminderDto { ReminderId = 4,
    //                         Name = "repair the car",
    //                         Date = Convert.ToDateTime("17.11.2017"),
    //                         Description = "Test4",
    //                         Action = "Test4",
    //                         ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
    //                         CategoryId = 1,
    //                         ImageId = 1
    //                       },
    //        new MyReminderDto { ReminderId = 5,
    //                         Name = "repair the car",
    //                         Date = Convert.ToDateTime("17.11.2017"),
    //                         Description = "Test5",
    //                         Action = "Test5",
    //                         ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
    //                         CategoryId = 1,
    //                         ImageId = 1
    //                       },
    //        new MyReminderDto { ReminderId = 6,
    //                        Name = "To have a deal",
    //                         Date = Convert.ToDateTime("17.11.2017"),
    //                         Description = "Test6",
    //                         Action = "Test6",
    //                         ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
    //                         CategoryId = 3,
    //                         ImageId = 1
    //                       },
    //        new MyReminderDto { ReminderId = 7,
    //                         Name = "Meeting with family",
    //                         Date = Convert.ToDateTime("17.11.2017"),
    //                         Description = "Test7",
    //                         Action = "Test7",
    //                         ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
    //                         CategoryId = 2,
    //                         ImageId = 1
    //                       }
    //    };


    //    public List<MyReminderDto> GetMyReminder()
    //    {
    //        return ReminderList;
    //    }
    //}
}
