using Reminder.Business.Model;
using Reminder.Business.Providers;
using StructureMap.Configuration.DSL;

namespace Reminder.Business.Container
{
    public class BusinessRegistry: Registry
    {
        public BusinessRegistry()
        {
            For<ICategoryProvider>().Use<CategoryProvider>();
            For<IUserProvider>().Use<UserProvider>();
            For<IReminderProvider>().Use<ReminderProvider>();
        }
    }
}
