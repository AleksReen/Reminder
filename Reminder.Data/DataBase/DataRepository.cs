using Reminder.Data.Clients;
using Reminder.Data.DataProviders;
using Reminder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data.DataBase
{
    //class emulates the database
    public class DataRepository: IDataRepository
    {
        ICategoryClient _category;

        public DataRepository(ICategoryClient s)
        {
            _category = s;
        }
        ////fake table Category
        //List<Category> Category = new List<Category>() {
        //    new Category { CategoryId = 1, Name =  "Home"},
        //    new Category { CategoryId = 2, Name =  "Family"},
        //    new Category { CategoryId = 3, Name =  "Business"},
        //}; 

        //fake table Reminder
        List<MyReminder> ReminderList = new List<MyReminder>()
        {
            new MyReminder { ReminderId = 1,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test",
                             Action = "Test",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 2,
                             Name = "Meeting with family",
                             Date = Convert.ToDateTime("18.11.2017"),
                             Description = "Test2",
                             Action = "Test2",
                             ReminderTime = Convert.ToDateTime("18.11.2017 12:45"),
                             CategoryId = 2,
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 3,
                             Name = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test3",
                             Action = "Test3",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 3,
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 4,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test4",
                             Action = "Test4",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 5,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test5",
                             Action = "Test5",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 6,
                            Name = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test6",
                             Action = "Test6",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 3,
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 7,
                             Name = "Meeting with family",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test7",
                             Action = "Test7",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 2,
                             ImageId = 1
                           }
        };

        //method invokes a list of reminders
        public IEnumerable<MyReminder> GetMyReminder()
        {
            return ReminderList;
        }
        //method enumerates a list of categories
        public IEnumerable<Category> GetCategory()
        {
            return _category.GetCategories();
        }
    }
}
