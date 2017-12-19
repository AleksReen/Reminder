using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Required field Category Name")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

    }
}
