using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System.Collections.Generic;

namespace Reminder.Data.Clients
{
    public interface ICategoryClient
    {
       IReadOnlyList<Category> GetCategories();
       ServerResponse AddCategory(string categoryName);
       ServerResponse EditeCategory(int categoryId, string categoryName);
       ServerResponse DeleteCategory(int categotryId);
    }
}
