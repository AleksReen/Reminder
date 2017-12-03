using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.Clients
{
    public interface IReminderClient
    {
        IReadOnlyList<MyReminder> GetReminders(int userId);
        ReminderInfo GetReminderInfo(int id);
    }
}
