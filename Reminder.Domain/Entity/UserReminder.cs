using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    public class UserReminder
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Required field Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Required field Email")]
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
    }
}