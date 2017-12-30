using Reminder.Common.Entity;
using Reminder.Common.Enums;
using System.Collections.Generic;

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
