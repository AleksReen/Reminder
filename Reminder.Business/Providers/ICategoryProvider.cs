﻿using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Business.Providers
{
    public interface ICategoryProvider
    {
        IReadOnlyList<Category> GetCategories();
        ServerResponse AddCategory(string categoryName);
        ServerResponse EditeCategory(int categoryId, string categoryName);
        ServerResponse DeleteCategory(int categotryId);
    }
}
