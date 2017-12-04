using Reminder.Common.Entity;
using Reminder.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewReminderList
    {
        public UserPrincipal CurrentUser { get; set; }

        public IOrderedEnumerable<MyReminder> Reminders { get; set; }
    }
}