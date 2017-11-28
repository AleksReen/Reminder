using Reminder.Common.Entity;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewReminderFullInfo
    {
        public MyReminder Reminder { get; set; }
        public ReminderInfo ReminderInfo { get; set; }
        public Category Category { get; set; }
    }
}