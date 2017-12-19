using Reminder.Data.Repository;
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
            For<IUserRepository>().Use<UserRepository>();
            For<IDataRepository>().Use<DataRepository>();
        }
    }
}
