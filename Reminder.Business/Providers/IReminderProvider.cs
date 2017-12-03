using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Business.Providers
{
    //provides an interface for class BusinessModel
    public interface IReminderProvider
    {
        //method invokes a list of reminders
        IReadOnlyList<MyReminder> GetReminders(int userId);
        //method enumerates a list of categories
        IReadOnlyList<Category> GetCategories();

        ReminderInfo GetReminderInfo(int id);
    }
}
