using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public string Email { get; set; }
        [DataMember]
        public RoleDto UserRole { get; set; }
    }
}
