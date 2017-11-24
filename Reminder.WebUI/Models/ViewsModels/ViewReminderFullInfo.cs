using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewReminderFullInfo
    {
        public MyReminder Reminder { get; set; }
        public ReminderInfo ReminderInfo { get; set; }
        public Category Category { get; set; }
    }
}