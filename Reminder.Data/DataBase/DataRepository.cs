using Reminder.Common.Entity;
using Reminder.Data.Clients;
using Reminder.Data.DataProviders;
using System.Collections.Generic;

namespace Reminder.Data.DataBase
{
    //class emulates the database
    public class DataRepository: IDataRepository
    {
        private ICategoryClient _categoryClient;
        private IReminderClient _remClient;

        public DataRepository(ICategoryClient catClient, IReminderClient remClient)
        {
            _categoryClient = catClient;
            _remClient = remClient;
        }
 
        //method invokes a list of reminders
        public IReadOnlyList<MyReminder> GetMyReminders(int userId)
        {
            return _remClient.GetReminders(userId);
        }
        //method enumerates a list of categories
        public IReadOnlyList<Category> GetCategories()
        {
            return _categoryClient.GetCategories();
        }

        public ReminderInfo GetReminderInfo(int id)
        {
            return _remClient.GetReminderInfo(id);
        }
    }
}
