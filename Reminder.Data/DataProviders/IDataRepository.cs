using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.DataProviders
{
    //provides an interface for class Data
    public interface IDataRepository
    {
        //method invokes a list of reminders
        IEnumerable<MyReminder> GetMyReminder();

        //method enumerates a list of categories
        IEnumerable<Category> GetCategory();

        ReminderInfo GetReminderInfo(int id);
    }
}
