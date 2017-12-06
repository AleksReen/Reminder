using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Areas.Editor.Models
{
    public class DeleteCategory
    {
        [Required(ErrorMessage = "Required field category")]
        [Display(Name = "Category name")]
        public int Category { get; set; }
        public string Message { get; set; }
    }
}