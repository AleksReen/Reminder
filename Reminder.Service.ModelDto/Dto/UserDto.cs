using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reminder.Service.ModelDto.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public List<string> Roles { get; set; }

        public UserDto()
        {
            Roles = new List<string>();
        }
    }
}
