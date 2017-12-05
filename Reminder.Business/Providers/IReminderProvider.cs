using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Business.Providers
{
    public interface IReminderProvider
    {
        IReadOnlyList<MyReminder> GetReminders(int userId);
        ReminderInfo GetReminderInfo(int id);
    }
}
