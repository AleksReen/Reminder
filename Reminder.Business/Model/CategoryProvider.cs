using Reminder.Business.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Common.Entity;
using Reminder.Data.DataProviders;
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
            return ServerResponse.NoError;
        }

        public ServerResponse DeleteCategory(int categotryId)
        {
            throw new NotImplementedException();
        }

        public ServerResponse EditeCategory(int categoryId, string categoryName)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _dataProvider.GetCategories();
        }
    }
}
