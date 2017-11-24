﻿using Reminder.Data.DataProviders;
using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Business.Providers
{
    //provides an interface for class BusinessModel
    public interface IReminderProvider
    {
        //method invokes a list of reminders
        IEnumerable<MyReminder> GetReminders { get; }
        //method enumerates a list of categories
        IEnumerable<Category> GetCategory { get; }

        ReminderInfo GetReminderDescription(int id);
    }
}
