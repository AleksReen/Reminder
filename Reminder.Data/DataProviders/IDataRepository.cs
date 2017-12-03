using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System.Collections.Generic;

namespace Reminder.Data.DataProviders
{
    //provides an interface for class Data
    public interface IDataRepository
    {
        //method invokes a list of reminders
        IReadOnlyList<MyReminder> GetMyReminders(int userId);

        //method enumerates a list of categories
        IReadOnlyList<Category> GetCategories();

        ReminderInfo GetReminderInfo(int id);
    }
}
