using Reminder.Business.Model;
using Reminder.Business.Providers;
using StructureMap.Configuration.DSL;

namespace Reminder.Business.Container
{
    public class BusinessRegistry: Registry
    {
        public BusinessRegistry()
        {
            For<IReminderProvider>().Use<ReminderProvider>();
        }
    }
}
