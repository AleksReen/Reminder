using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Common.Entity
{
    public class ReminderInfo
    {
        public MyReminder Reminder { get; set; }
        public List<string> Actions { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public ReminderInfo()
        {
            Reminder = new MyReminder();
            Actions = new List<string>();
        }
    }
}
