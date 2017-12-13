using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Service.ModelDto.Dto
{
    [DataContract]
    public class ImgPathDto
    {
        [DataMember]
        public string Path { get; set; }
    }
}
