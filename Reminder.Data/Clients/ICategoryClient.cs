using Reminder.Common.Entity;
using System.Collections.Generic;

namespace Reminder.Data.Clients
{
    public interface ICategoryClient
    {
       IReadOnlyList<Category> GetCategories();
    }
}
