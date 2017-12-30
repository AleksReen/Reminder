using System.ComponentModel.DataAnnotations;

namespace Reminder.WebUI.Areas.Editor.Models
{
    public class ViewModelCreateCategory
    {
        [Required(ErrorMessage = "Required field Category Name")]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        public string Message { get; set; }
    }
}