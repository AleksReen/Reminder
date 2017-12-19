using Reminder.Common.Entity;
using Reminder.Common.Enums;
using Reminder.Data.Clients;
using System;
using System.Collections.Generic;

namespace Reminder.Data.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private ICategoryClient _categoryClient;

        public CategoryRepository(ICategoryClient catClient)
        {
            if (catClient == null)
            {
                throw new ArgumentException("Parameter cannot be null", "catClient");
            }
            _categoryClient = catClient;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _categoryClient.GetCategories();
        }

        public ServerResponse AddCategory(string categoryName)
        {
            return _categoryClient.AddCategory(categoryName);
        }

        public ServerResponse EditeCategory(int categoryId, string categoryName)
        {
            return _categoryClient.EditeCategory(categoryId, categoryName);
        }

        public ServerResponse DeleteCategory(int categoryId)
        {
            return _categoryClient.DeleteCategory(categoryId);
        }
    }
}
