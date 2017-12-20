using System.Collections.Generic;

namespace Reminder.Common.Entity
{
    public class ReminderInfo
    {
        public MyReminder Reminder { get; set; }
        public List<string> Actions { get; set; }
        public string Description { get; set; }
        public ReminderInfo()
        {
            Reminder = new MyReminder();
            Actions = new List<string>();
        }
    }
}
