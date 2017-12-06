using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Areas.Editor.Models
{
    public class ViewModelEditeCategory
    {
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public string Message { get; set; }
    }
}