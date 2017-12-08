using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Service.ModelDto.Dto
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public List<RoleDto> Roles { get; set; }

        public UserInfo()
        {
            Roles = new List<RoleDto>();
        }
    }
}
