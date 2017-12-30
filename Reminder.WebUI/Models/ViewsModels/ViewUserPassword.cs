using System.ComponentModel.DataAnnotations;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewUserPassword
    {
        [Required(ErrorMessage = "Required field Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password do not match")]
        public string RePassword { get; set; }
    }
}