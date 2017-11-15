using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.FakeModel
{
    public class FakeClass : IFakeInterface
    {
        public void CreateSomeError()
        {
            throw new Exception ("Fake Error - test DI and Logger");
        }

        public string GetStaticMessage()
        {
            return "Message from FakeClass";
        }
    }
}
