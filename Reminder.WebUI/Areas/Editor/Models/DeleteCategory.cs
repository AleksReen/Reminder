using System.ComponentModel.DataAnnotations;

namespace Reminder.WebUI.Areas.Editor.Models
{
    public class DeleteCategory
    {
        [Required(ErrorMessage = "Required field category")]
        [Display(Name = "Category name")]
        public int CategoryId { get; set; }
        public string Message { get; set; }
    }
}