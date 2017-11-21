using Reminder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data.DataProviders
{
    //provides an interface for class Data
    public interface IDataRepository
    {
        //method invokes a list of reminders
        IEnumerable<MyReminder> GetMyReminder();

        //method enumerates a list of categories
        IEnumerable<Category> GetCategory();
    }
}
