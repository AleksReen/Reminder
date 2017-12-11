using System;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    //essence describing Category
    public class MyReminder
    {
        public int ReminderId { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }       
        public DateTime ReminderTime { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
