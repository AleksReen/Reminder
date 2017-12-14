using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System;
using System.Collections.Generic;

namespace Reminder.Data.Clients
{
    public interface IReminderClient
    {
        IReadOnlyList<MyReminder> GetReminders(int userId);
        ReminderInfo GetReminderInfo(int id);
        ServerResponse AddReminder(string title, DateTime date, DateTime dateReminder, string image, int categoryId, int userId, string actions, string descriptions);
        ServerResponse UpdateReminder(int reminderId, string title, DateTime date, DateTime dateReminder, string image, int categoryId, string actions, string descriptions);
        string DeleteReminder(int id);
    }
}
