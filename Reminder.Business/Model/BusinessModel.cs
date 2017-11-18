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
   public class BusinessModel : IReminderProvider
    {
        private readonly IDataProvider _dataProvider;

        public BusinessModel(IDataProvider provider)
        {
            _dataProvider = provider;
        }

        public List<string> GetCategory
        {
            get
            {
                return _dataProvider.GetMyReminder().Select(x => x.CategoryId).Distinct().ToList();
            }
        }

        public List<MyReminder> GetReminders
        {
            get
            {
                return _dataProvider.GetMyReminder();
            }
        }

    }
}
