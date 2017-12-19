﻿using Reminder.Business.Providers;
using System.Collections.Generic;
using Reminder.Common.Entity;
using Reminder.Data.Repository;
using Reminder.Common.Enums;

namespace Reminder.Business.Model
{
    public class CategoryProvider : ICategoryProvider
    {
        private IDataRepository _dataProvider;

        public CategoryProvider(IDataRepository provider)
        {
            _dataProvider = provider;
        }

        public ServerResponse AddCategory(string categoryName)
        {
            return _dataProvider.AddCategory(categoryName);
        }

        public ServerResponse DeleteCategory(int categoryId)
        {
            return _dataProvider.DeleteCategory(categoryId);
        }

        public ServerResponse EditeCategory(int categoryId, string categoryName)
        {
            return _dataProvider.EditeCategory(categoryId, categoryName);
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _dataProvider.GetCategories();
        }
    }
}
