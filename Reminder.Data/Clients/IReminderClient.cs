using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.Clients
{
    public interface IReminderClient
    {
        IReadOnlyList<MyReminder> GetReminders();
        ReminderInfo GetReminderInfo(int id);
    }
}
