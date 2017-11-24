using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Common.Entity;

namespace Reminder.Data.Clients
{
    public class ReminderClient : IReminderClient
    {
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
