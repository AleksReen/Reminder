using Reminder.Data.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Business.Providers
{
    public interface IBusinessProvider
    {
        IDataProvider GetData();
    }
}
