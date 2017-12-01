
namespace Reminder.Common.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public Role[] Roles { get; set; }
    }
}