﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    //essence describing Category
    public class MyReminder
    {
        public int ReminderId { get; set; }

        [Required(ErrorMessage = "Required field Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required field Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required field ReminderTime")]
        public DateTime ReminderTime { get; set; }
        public string Image { get; set; }
        
        public int CategoryId { get; set; }

        public int UserId { get; set; }
    }
}
