using Reminder.WebUI.Models.Entity;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewReminderIndex
    {
        public UserPrincipal CurrentUser { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}