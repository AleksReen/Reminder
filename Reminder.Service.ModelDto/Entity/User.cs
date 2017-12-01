using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Service.ModelDto.Entity
{   
        public class User
        {
            public int UserId { get; set; }
            public string Login { get; set; }
            public List<string> Roles { get; set; }
        }
}
