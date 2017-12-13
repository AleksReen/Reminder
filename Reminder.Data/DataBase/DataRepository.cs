using Reminder.Common.Entity;
using Reminder.Data.Clients;
using Reminder.Data.DataProviders;
using System.Collections.Generic;
using Reminder.Common.Enums;
using System;

namespace Reminder.Data.DataBase
{
    public class DataRepository: IDataRepository
    {
        private ICategoryClient _categoryClient;
        private IReminderClient _remClient;

        public DataRepository(ICategoryClient catClient, IReminderClient remClient)
        {
            _categoryClient = catClient;
            _remClient = remClient;
        }

        public IReadOnlyList<MyReminder> GetMyReminders(int userId)
        {
            return _remClient.GetReminders(userId);
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _categoryClient.GetCategories();
        }

        public ReminderInfo GetReminderInfo(int id)
        {
            return _remClient.GetReminderInfo(id);
        }

        public ServerResponse AddCategory(string categoryName)
        {
            return _categoryClient.AddCategory(categoryName);
        }

        public ServerResponse EditeCategory(int categoryId, string categoryName)
        {
            return _categoryClient.EditeCategory(categoryId, categoryName);
        }

        public ServerResponse DeleteCategory(int categoryId)
        {
            return _categoryClient.DeleteCategory(categoryId);
        }

        public ServerResponse AddReminder(string title, DateTime date, DateTime dateReminder, string image, int categoryId, int userId, string actions, string descriptions)
        {
            return _remClient.AddReminder(title, date, dateReminder, image, categoryId, userId, actions, descriptions);
        }

        public string DeleteReminder(int id)
        {
            return _remClient.DeleteReminder(id);
        }
    }
}
