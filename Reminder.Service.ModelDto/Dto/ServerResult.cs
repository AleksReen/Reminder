using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Service.ModelDto.Dto
{
    [DataContract]
    public class ServerResultDto
    {
        [DataMember]
        public int Result { get; set; }
    }
}
