using System;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    public class MyReminder
    {
        public int ReminderId { get; set; }

        [Required(ErrorMessage = "Required field Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required field Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required field ReminderTime")]
        [Display(Name = "Reminder Time")]
        public DateTime ReminderTime { get; set; }
        public string Image { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        public int UserId { get; set; }

        public MyReminder()
        {
            Category = new Category();
        }
    }
}
