using Reminder.Data.DataProviders;
using Reminder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data.DataBase
{
    public class Data: IDataProvider
    {
        List<MyReminder> ReminderList = new List<MyReminder>()
        {
            new MyReminder { ReminderId = 1,
                            
                             Date = Convert.ToDateTime("17.11.2017"),
                             Name = "repair the car",
                             Description = "Test",
                             Action = "Test",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = "Home",
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 2,
                             Name = "Meeting with family",
                             Date = Convert.ToDateTime("18.11.2017"),
                             Description = "Test2",
                             Action = "Test2",
                             ReminderTime = Convert.ToDateTime("18.11.2017 12:45"),
                             CategoryId = "Family",
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 3,
                             Name = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test3",
                             Action = "Test3",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = "Business",
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 4,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test4",
                             Action = "Test4",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = "Home",
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 5,
                             Name = "repair the car",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test5",
                             Action = "Test5",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = "Home",
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 6,
                            Name = "To have a deal",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test6",
                             Action = "Test6",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = "Business",
                             ImageId = 1
                           },
            new MyReminder { ReminderId = 7,
                             Name = "Meeting with family",
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test7",
                             Action = "Test7",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = "Family",
                             ImageId = 1
                           }
        };

        public List<MyReminder> GetMyReminder()
        {
            return ReminderList;
        }
    }
}
