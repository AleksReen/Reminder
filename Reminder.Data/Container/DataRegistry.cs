using Reminder.Data.DataProviders;
using Reminder.Data.DataBase;
using StructureMap.Configuration.DSL;
using Reminder.Data.Clients;

namespace Reminder.Data.Container
{
    public class DataRegistry: Registry
    {
        public DataRegistry()
        {
            For<IReminderClient>().Use<ReminderClient>();
            For<ICategoryClient>().Use<CategoryClient>();
            For<IDataRepository>().Use<DataRepository>();
        }
    }
}
