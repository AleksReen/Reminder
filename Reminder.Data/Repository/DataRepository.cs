using Reminder.Common.Entity;
using Reminder.Data.Clients;
using Reminder.Data.Repository;
using System.Collections.Generic;
using Reminder.Common.Enums;
using System;

namespace Reminder.Data.Repository
{
    public class DataRepository: IDataRepository
    {
        private IReminderClient _remClient;

        public DataRepository(ICategoryClient catClient, IReminderClient remClient)
        {
            _remClient = remClient;
        }

        public IReadOnlyList<MyReminder> GetMyReminders(int userId)
        {
            return _remClient.GetReminders(userId);
        }

        public ReminderInfo GetReminderInfo(int id)
        {
            return _remClient.GetReminderInfo(id);
        }

        public ServerResponse AddReminder(string title, DateTime date, DateTime dateReminder, string image, int categoryId, int userId, string actions, string descriptions)
        {
            return _remClient.AddReminder(title, date, dateReminder, image, categoryId, userId, actions, descriptions);
        }

        public string DeleteReminder(int id)
        {
            return _remClient.DeleteReminder(id);
        }

        public ServerResponse UpdateReminder(int reminderId, string title, DateTime date, DateTime dateReminder, string image, int categoryId, string actions, string descriptions)
        {
            return _remClient.UpdateReminder(reminderId, title, date, dateReminder, image, categoryId, actions, descriptions);
        }
    }
}
