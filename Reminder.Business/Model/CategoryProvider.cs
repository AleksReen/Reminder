using Reminder.Business.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Common.Entity;
using Reminder.Data.DataProviders;

namespace Reminder.Business.Model
{
    public class CategoryProvider : ICategoryProvider
    {
        private IDataRepository _dataProvider;

        public CategoryProvider(IDataRepository provider)
        {
            _dataProvider = provider;
        }
        public IReadOnlyList<Category> GetCategories()
        {
            return _dataProvider.GetCategories();
        }
    }
}
