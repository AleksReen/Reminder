using Reminder.Business.Providers;
using Reminder.Data.DataProviders;
using Reminder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reminder.Business.Model
{
    //class processes data from the database
   public class BusinessModel : IReminderProvider
    {
        //link to dependency on class Data
        private  IDataProvider _dataProvider;

        public BusinessModel(IDataProvider provider)
        {
            _dataProvider = provider;
        }

        //the property returns the processed value Category
        public IEnumerable<Category> GetCategory
        {
            get
            {
                return _dataProvider.GetCategory().OrderBy(x=>x.Name);
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
