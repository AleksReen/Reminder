using System.Collections.Generic;

namespace Reminder.Common.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public List<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}