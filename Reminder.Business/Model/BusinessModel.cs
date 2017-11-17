using Reminder.Business.Providers;
using Reminder.Data.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reminder.Business.Model
{
   public class BusinessModel : IBusinessProvider
    {
        private IDataProvider _dataProvider;

        public BusinessModel(IDataProvider provider)
        {
            _dataProvider = provider;
        }

        public IDataProvider GetData()
        {
            return _dataProvider;
        }
    }
}
