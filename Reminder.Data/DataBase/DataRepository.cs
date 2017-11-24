using Reminder.Common.Entity;
using Reminder.Data.Clients;
using Reminder.Data.DataProviders;
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
                             Title = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),                             
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             Image = "not found"
                           },
            new MyReminder { ReminderId = 2,
                             Title = "Meeting with family",
                             Date = Convert.ToDateTime("18.11.2017"),
                             ReminderTime = Convert.ToDateTime("18.11.2017 12:45"),
                             CategoryId = 2,
                             Image = "not found"
                           },
            new MyReminder { ReminderId = 3,
                             Title = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),                            
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 3,
                             Image = "not found"
                           },
            new MyReminder { ReminderId = 4,
                             Title = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             Image = "not found"
                           },
            new MyReminder { ReminderId = 5,
                             Title = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             Image = "not found"
                           },
            new MyReminder { ReminderId = 6,
                            Title = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 3,
                             Image = "not found"
                           },
            new MyReminder { ReminderId = 7,
                             Title = "Meeting with family",
                             Date = Convert.ToDateTime("17.11.2017"),
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 2,
                             Image = "not found"
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
