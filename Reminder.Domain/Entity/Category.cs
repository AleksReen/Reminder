﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Common.Entity
{
    //essence describing Category
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Required field Category Name")]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }

    }
}
