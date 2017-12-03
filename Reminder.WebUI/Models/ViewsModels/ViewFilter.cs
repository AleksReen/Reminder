using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewFilter
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Category { get; set; }
    }
}