using System.Runtime.Serialization;

namespace Reminder.Service.Contracts.Models.Dto
{
    [DataContract]
    public class ReminderInfoDto
    {
        [DataMember]
        public int ReminderId { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}