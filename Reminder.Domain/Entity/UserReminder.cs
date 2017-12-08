using System.Collections.Generic;

namespace Reminder.Common.Entity
{
    public class UserReminder
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
    }
}