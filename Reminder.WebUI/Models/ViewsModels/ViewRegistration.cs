using System.ComponentModel.DataAnnotations;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewRegistration
    {
        [Required(ErrorMessage = "Required field Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Required field Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password do not match")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email (must be - example@ex.ex)")]
        public string Email { get; set; }

        public string Message { get; set; }
    }
}