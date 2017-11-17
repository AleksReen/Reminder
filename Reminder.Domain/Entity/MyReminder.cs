using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.Entity
{
    public class MyReminder
    {
        public int ReminderId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public DateTime ReminderTime { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; }
    }
}
