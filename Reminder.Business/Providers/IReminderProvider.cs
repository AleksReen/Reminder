using Reminder.Data.DataProviders;
using Reminder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Business.Providers
{
    public interface IReminderProvider
    {
        List<MyReminder> GetReminders { get; }
        List<string> GetCategory { get; }
    }
}
