using Reminder.Common.Entity;
using Reminder.Data.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Common.Enums;
using Reminder.Data.Clients;

namespace Reminder.Data.DataBase
{
    public class CategoryRepository : ICategoryRepository
    {
        private ICategoryClient _categoryClient;
        public CategoryRepository(ICategoryClient catClient)
        {
            _categoryClient = catClient;
        }
        public ServerResponse AddCategory(string categoryName)
        {
            throw new NotImplementedException();
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
            return _categoryClient.GetCategories();
        }
    }
}
