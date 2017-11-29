using Reminder.Business.Providers;
using Reminder.Data.DataProviders;
using Reminder.Common.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Business.Model
{
    //class processes data from the database
   public class ReminderProvider : IReminderProvider
    {
        //link to dependency on class Data
        private  IDataRepository _dataProvider;

        public ReminderProvider(IDataRepository provider)
        {
            _dataProvider = provider;
        }

        //the property returns the processed value Category
        public IReadOnlyList<Category> GetCategories()
        {
            return _dataProvider.GetCategories();
        }
        //the property returns the processed value Category
        public IReadOnlyList<MyReminder> GetReminders()
        {
            return _dataProvider.GetMyReminders();
        }

        public ReminderInfo GetReminderInfo(int id)
        {
            return _dataProvider.GetReminderInfo(id);
        }
    }
}
