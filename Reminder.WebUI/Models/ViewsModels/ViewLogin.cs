using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewLogin
    {        
        [Required(ErrorMessage = "Required field Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Required field Password")]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}