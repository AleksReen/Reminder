using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reminder.Service.Contracts.Models.Dto
{
    [DataContract]
    public class ReminderInfoDto
    {
        [DataMember]
        public MyReminderDto Reminder { get; set; }

        [DataMember]
        public List<string> Actions { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Category { get; set; }

        public ReminderInfoDto()
        {
            Reminder = new MyReminderDto();
            Actions = new List<string>();
        }
    }
}