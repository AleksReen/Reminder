using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Reminder.Service.Contracts.Models.Dto
{
    [DataContract]
    public class MyReminderDto
    {
        [DataMember]
        public int ReminderId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime ReminderTime { get; set; }
        [DataMember]
        public int Image { get; set; }
        [DataMember]
        public int CategoryId { get; set; }       
    }
}