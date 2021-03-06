﻿using System.Collections.Generic;
using System.Linq;
using Reminder.Common.Entity;
using System.ServiceModel;
using Reminder.Common.Enums;
using System;
using log4net;

namespace Reminder.Data.Clients
{
    public class ReminderClient : IReminderClient
    {
        private ILog logger;

        public ReminderClient()
        {
            logger = LogManager.GetLogger("LOGGER");
        }
        public ServerResponse AddReminder(string title, DateTime date, DateTime dateReminder, string image, int categoryId, int userId, string actions, string descriptions)
        {
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.AddReminder(title, date, dateReminder, image, categoryId, userId, actions, descriptions);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

        public string DeleteReminder(int id)
        {
           
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.DeleteReminder(id);

                    client.Close();

                    if (!string.IsNullOrEmpty(resultDto))
                    {
                        return resultDto;
                    }

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return default(string);
        }

        public ReminderInfo GetReminderInfo(int id)
        {
            var reminderInfo = new ReminderInfo();
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var reminderInfoDto = client.GetReminderInfo(id);

                    client.Close();

                    if (reminderInfoDto != null)
                    {
                        reminderInfo.Reminder.ReminderId = reminderInfoDto.Reminder.ReminderId;
                        reminderInfo.Reminder.Title = reminderInfoDto.Reminder.Title;
                        reminderInfo.Reminder.Date = reminderInfoDto.Reminder.Date;
                        reminderInfo.Reminder.ReminderTime = reminderInfoDto.Reminder.ReminderTime;
                        reminderInfo.Reminder.Image = reminderInfoDto.Reminder.Image;
                        reminderInfo.Reminder.Category.CategoryId = reminderInfoDto.Reminder.CategoryId;
                        reminderInfo.Reminder.Category.CategoryName = reminderInfoDto.Reminder.CategoryName;

                        reminderInfo.Actions = reminderInfoDto.Actions.ToList();
                        reminderInfo.Description = reminderInfoDto.Description;
                    }  
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
                
            }

            return reminderInfo;
        }

        public IReadOnlyList<MyReminder> GetReminders(int userId)
        {
            var listReminders = new List<MyReminder>();
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var remindersDto = client.GetAllReminders(userId);

                    client.Close();

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
                                Category = new Category()
                                {
                                    CategoryId = reminder.CategoryId,
                                    CategoryName = reminder.CategoryName
                                }
                            };

                            listReminders.Add(rem);
                        }
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
                
            }
            return listReminders;
        }

        public ServerResponse UpdateReminder(int reminderId, string title, DateTime date, DateTime dateReminder, string image, int categoryId, string actions, string descriptions)
        {
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.UpdateReminder(reminderId, title, date, dateReminder, image, categoryId, actions, descriptions);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }
    }
}
