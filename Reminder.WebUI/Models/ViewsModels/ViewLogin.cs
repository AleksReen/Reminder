using System.ComponentModel.DataAnnotations;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewLogin
    {        
        [Required(ErrorMessage = "Required field Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Required field Password")]
        public string Password { get; set; }

        public string Message { get; set; }
        public bool Result { get; set; }
    }
}