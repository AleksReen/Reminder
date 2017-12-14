using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System;
using System.Collections.Generic;

namespace Reminder.Data.DataProviders
{
    public interface IDataRepository
    {
        IReadOnlyList<MyReminder> GetMyReminders(int userId);
        IReadOnlyList<Category> GetCategories();
        ReminderInfo GetReminderInfo(int id);
        ServerResponse AddCategory(string categoryName);
        ServerResponse EditeCategory(int categoryId, string categoryName);
        ServerResponse DeleteCategory(int categotryId);
        ServerResponse AddReminder(string title, DateTime date, DateTime dateReminder, string image, int categoryId, int userId, string actions, string descriptions);
        ServerResponse UpdateReminder(int reminderId, string title, DateTime date, DateTime dateReminder, string image, int categoryId, string actions, string descriptions);
        string DeleteReminder(int id);
    }
}
