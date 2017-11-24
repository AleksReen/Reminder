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
        ICategoryClient _categoryClient;
        IReminderClient _remClient;

        public DataRepository(ICategoryClient catClient, IReminderClient remClient)
        {
            _categoryClient = catClient;
            _remClient = remClient;
        }
 
        //method invokes a list of reminders
        public IEnumerable<MyReminder> GetMyReminder()
        {
            return _remClient.GetReminders();
        }
        //method enumerates a list of categories
        public IEnumerable<Category> GetCategory()
        {
            return _categoryClient.GetCategories();
        }

        public ReminderInfo GetReminderDescription(int id)
        {
            return _remClient.GetReminderDescription(id);
        }
    }
}
