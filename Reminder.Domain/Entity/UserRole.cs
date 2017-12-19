using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    public class UserRole
    {
        public int RoleId { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
