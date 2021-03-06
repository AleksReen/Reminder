﻿using Reminder.Common.Entity;
using System.Collections.Generic;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewNewReminder
    {
        public MyReminder Reminder { get; set; }
        public List<string> Actions { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Message { get; set; }
    }
}