using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    public class Category
    {
        [Required(ErrorMessage = "Required field Category Name")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

    }
}
