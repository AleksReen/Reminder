using Reminder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewReminderList
    {
        public List<MyReminder> Reminders { get; set; }
    }
}