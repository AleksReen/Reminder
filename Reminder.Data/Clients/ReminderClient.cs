﻿using System.Collections.Generic;
using System.Linq;
using Reminder.Common.Entity;

namespace Reminder.Data.Clients
{
    public class ReminderClient : IReminderClient
    {
        public ReminderInfo GetReminderInfo(int id)
        {
            var reminderInfo = new ReminderInfo();
            using (var client = new ReminderService.ReminderServiceClient())
            {
                client.Open();

                var reminderInfoDto = client.GetReminderInfo(id);

                if (reminderInfoDto != null)
                {
                    reminderInfo.Reminder.ReminderId = reminderInfoDto.Reminder.ReminderId;
                    reminderInfo.Reminder.Title = reminderInfoDto.Reminder.Title;
                    reminderInfo.Reminder.Date = reminderInfoDto.Reminder.Date;
                    reminderInfo.Reminder.ReminderTime = reminderInfoDto.Reminder.ReminderTime;
                    reminderInfo.Reminder.Image = reminderInfoDto.Reminder.Image;
                    reminderInfo.Reminder.CategoryId = reminderInfoDto.Reminder.CategoryId;

                    reminderInfo.Actions = reminderInfoDto.Actions.ToList<string>();
                    reminderInfo.Category = reminderInfoDto.Category;
                    reminderInfo.Description = reminderInfoDto.Description;
                }

                client.Close();
            }
            return reminderInfo;

        }

        public List<MyReminder> GetReminders()
        {
            var listReminders = new List<MyReminder>();
            using (var client = new ReminderService.ReminderServiceClient())
            {
                client.Open();

                var remindersDto = client.GetAllReminders();

                if (remindersDto != null)
                {
                    foreach (var reminder in remindersDto)
                    {
                        var rem = new MyReminder()
                        {
                            ReminderId = reminder.ReminderId,
                            Title = reminder.Title,
                            Date = reminder.Date,
                            ReminderTime = reminder.ReminderTime,
                            Image = reminder.Image,
                            CategoryId = reminder.CategoryId
                        };
                        listReminders.Add(rem);
                    }
                }

                client.Close();
            }
            return listReminders;
        }
    }
}