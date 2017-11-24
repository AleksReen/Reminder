using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.WebUI.Models.ViewsModels
{
    public class ViewCategoryList
    {
        public IEnumerable<Category> Categories { get; set; } 
    }
}