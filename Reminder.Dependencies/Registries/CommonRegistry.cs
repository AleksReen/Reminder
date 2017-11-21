using Reminder.Business.Container;
using Reminder.Data.Container;
using StructureMap.Configuration.DSL;

namespace Reminder.Dependencies.Registries
{
    public class CommonRegistry: Registry
    {
        public CommonRegistry()
        {
            Scan(scan => {
                scan.Assembly(typeof(DataRegistry).Assembly);
                scan.Assembly(typeof(BusinessRegistry).Assembly);
                scan.WithDefaultConventions();
            });
        } 
    }
}
