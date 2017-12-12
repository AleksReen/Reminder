using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewNewReminder
    {
        public MyReminder Reminder { get; set; }
        public List<string> Actions { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Required field Category")]
        public int CategoryId { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}