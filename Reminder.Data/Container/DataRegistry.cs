using Reminder.Data.DataProviders;
using Reminder.Data.DataBase;
using StructureMap.Configuration.DSL;

namespace Reminder.Data.Container
{
    public class DataRegistry: Registry
    {
        public DataRegistry()
        {
            For<IDataRepository>().Use<DataBase.DataRepository>();
        }
    }
}
