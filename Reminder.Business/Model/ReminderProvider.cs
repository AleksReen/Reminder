﻿using Reminder.Business.Providers;
using Reminder.Data.DataProviders;
using Reminder.Common.Entity;
using System.Collections.Generic;
using System.Linq;
using Reminder.Common.Enums;
using System;

namespace Reminder.Business.Model
{
   public class ReminderProvider : IReminderProvider
    {
        private  IDataRepository _dataProvider;

        public ReminderProvider(IDataRepository provider)
        {
            _dataProvider = provider;
        }

        public IReadOnlyList<MyReminder> GetReminders(int userId)
        {
            return _dataProvider.GetMyReminders(userId);
        }

        public ReminderInfo GetReminderInfo(int id)
        {
            return _dataProvider.GetReminderInfo(id);
        }

        public ServerResponse AddReminder(string title, DateTime date, DateTime dateReminder, string image, int categoryId, int userId, string actions, string descriptions)
        {
            return _dataProvider.AddReminder(title, date, dateReminder, image, categoryId, userId, actions, descriptions);
        }
    }
}
