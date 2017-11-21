using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reminder.Service.Contracts.Models.Dto;

namespace Reminder.Service.Contracts
{
    public class ReminderService : IReminderService
    {

        //fake table Category
        List<CategoryDto> Category = new List<CategoryDto>() {
            new CategoryDto { CategoryId = 1, Name =  "Home"},
            new CategoryDto { CategoryId = 2, Name =  "Family"},
            new CategoryDto { CategoryId = 3, Name =  "Business"},
        };

        //fake table Reminder
        List<MyReminderDto> ReminderList = new List<MyReminderDto>()
        {
            new MyReminderDto { ReminderId = 1,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test",
                             Action = "Test",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             ImageId = 1
                           },
            new MyReminderDto { ReminderId = 2,
                             Name = "Meeting with family",
                             Date = Convert.ToDateTime("18.11.2017"),
                             Description = "Test2",
                             Action = "Test2",
                             ReminderTime = Convert.ToDateTime("18.11.2017 12:45"),
                             CategoryId = 2,
                             ImageId = 1
                           },
            new MyReminderDto { ReminderId = 3,
                             Name = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test3",
                             Action = "Test3",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 3,
                             ImageId = 1
                           },
            new MyReminderDto { ReminderId = 4,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test4",
                             Action = "Test4",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             ImageId = 1
                           },
            new MyReminderDto { ReminderId = 5,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test5",
                             Action = "Test5",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             ImageId = 1
                           },
            new MyReminderDto { ReminderId = 6,
                            Name = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test6",
                             Action = "Test6",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 3,
                             ImageId = 1
                           },
            new MyReminderDto { ReminderId = 7,
                             Name = "Meeting with family",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test7",
                             Action = "Test7",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 2,
                             ImageId = 1
                           }
        };

        public IEnumerable<CategoryDto> GetCategory()
        {
            return Category;
        }

        public IEnumerable<MyReminderDto> GetMyReminder()
        {
            return ReminderList;
        }
    }
}