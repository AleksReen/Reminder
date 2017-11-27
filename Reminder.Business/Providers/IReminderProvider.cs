using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Business.Providers
{
    //provides an interface for class BusinessModel
    public interface IReminderProvider
    {
        //method invokes a list of reminders
        IEnumerable<MyReminder> GetReminders { get; }
        //method enumerates a list of categories
        IEnumerable<Category> GetCategory { get; }

        ReminderInfo GetReminderInfo(int id);
    }
}
