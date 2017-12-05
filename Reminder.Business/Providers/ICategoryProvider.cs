using Reminder.Common.Entity;
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
    }
}
