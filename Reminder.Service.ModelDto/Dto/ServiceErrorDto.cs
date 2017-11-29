using System.Runtime.Serialization;

namespace Reminder.Service.ModelDto.Dto
{
    [DataContract]
    public class ServiceErrorDto
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Details { get; set; }
    }
}
