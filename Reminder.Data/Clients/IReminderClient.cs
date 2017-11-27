using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.Clients
{
    public interface IReminderClient
    {
        List<MyReminder> GetReminders();
        ReminderInfo GetReminderInfo(int id);
    }
}
