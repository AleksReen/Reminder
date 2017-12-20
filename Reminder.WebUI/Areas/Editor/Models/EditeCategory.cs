using System.ComponentModel.DataAnnotations;

namespace Reminder.WebUI.Areas.Editor.Models
{
    public class EditeCategory
    {
        [Required(ErrorMessage = "Required field category")]
        [Display(Name = "Category name")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required field new name")]
        [Display(Name = "New name")]
        public string NewName { get; set; }
        public string Message { get; set; }
    }
}