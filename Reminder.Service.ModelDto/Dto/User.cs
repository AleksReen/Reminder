using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Reminder.Service.ModelDto.Dto
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public List<string> Roles { get; set; }

        public User()
        {
            Roles = new List<string>();
        }
    }
}
