using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Common.Entity
{
    //essence describing Category
    public class MyReminder
    {
        public int ReminderId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }       
        public DateTime ReminderTime { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
