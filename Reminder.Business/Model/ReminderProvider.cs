using Reminder.Business.Providers;
using Reminder.Data.DataProviders;
using Reminder.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reminder.Business.Model
{
    //class processes data from the database
   public class ReminderProvider : IReminderProvider
    {
        //link to dependency on class Data
        private  IDataRepository _dataProvider;

        public ReminderProvider(IDataRepository provider)
        {
            _dataProvider = provider;
        }

        //the property returns the processed value Category
        public IEnumerable<Category> GetCategory
        {
            get
            {
                return _dataProvider.GetCategory().OrderBy(x=>x.CategoryName);
            }
        }
        //the property returns the processed value Category
        public IEnumerable<MyReminder> GetReminders
        {
            get
            {
                return _dataProvider.GetMyReminder();
            }
        }
    }
}
