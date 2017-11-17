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
        List<Category> СategoriesList = new List<Category>() {
           new Category { CategoryId = 1, Name = "Home" },
           new Category { CategoryId = 2, Name = "Family" },
           new Category { CategoryId = 3, Name = "Business" }
        };

        List<MyReminder> ReminderList = new List<MyReminder>()
        {
            new MyReminder { ReminderId = 1,
                             Date = Convert.ToDateTime("17.11.2017"),
                             Description = "Test",
                             Action = "Test",
                             ReminderTime = Convert.ToDateTime("17.11.2017 12:45"),
                             CategoryId = 1,
                             ImageId = 1
                           }
        };

        public List<Category> getCategory()
        {
            return СategoriesList;
        }

        public List<MyReminder> getMyReminder()
        {
            return ReminderList;
        }
    }
}
