using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data.Clients
{
    public interface IReminderClient
    {
        List<MyReminder> GetReminders();
        ReminderInfo GetReminderInfo(int id);
    }
}
